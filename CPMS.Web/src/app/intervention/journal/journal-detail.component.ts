import { Component, OnDestroy, OnInit } from '@angular/core';
import { ActivatedRoute, ParamMap } from "@angular/router";
import { JournalService } from "../../_services/journal.service";
import { switchMap } from "rxjs/operators";
import { JournalDetailDto } from "../../_models/journalDetailDto";
import { NgbModal } from "@ng-bootstrap/ng-bootstrap";
import { AddJournalEntryComponent } from "./add-journal-entry.component";
import { HubsService } from "../../_services/hubs.service";
import * as Excel from "exceljs/dist/exceljs.min.js";
import * as ExcelProper from "exceljs";
import * as fs from 'file-saver';

@Component({
    selector: 'app-journal-detail',
    templateUrl: './journal-detail.component.html',
    styleUrls: ['./journal-detail.component.css']
})
export class JournalDetailComponent implements OnInit, OnDestroy {

    public journalDetail: JournalDetailDto;
    public isCombinedJournal: boolean;
    public loading: boolean;

    constructor(private route: ActivatedRoute,
                private modalService: NgbModal,
                private journalService: JournalService,
                private hubsService: HubsService) {
    }

    private shouldRefresh(updatedInterventionId: number, updatedJournalId: number) {
        if (this.isCombinedJournal) {
            return this.journalDetail.intervention.id == updatedInterventionId;
        }

        return this.journalDetail.id == updatedJournalId;
    }

    ngOnInit() {
        this.loading = true;
        this.route.paramMap.pipe(
            switchMap((params: ParamMap) => {
                return this.journalService.getJournalDetail(params.get('interventionId'), params.get('journalId'));
            }))
            .subscribe(journalDetail => {
                this.journalDetail = journalDetail;
                this.isCombinedJournal = journalDetail.id == 0;
                this.loading = false;
            });

        this.hubsService.connect();
        this.hubsService.journalUpdated.subscribe(event => {
            if (this.journalDetail && this.shouldRefresh(event.interventionId, event.journalId)) {
                this.loading = true;
                this.journalService.getJournalDetail(event.interventionId, this.isCombinedJournal ? 0 : event.journalId)
                    .subscribe(journalDetail => {
                        this.loading = false;
                        this.journalDetail = journalDetail;
                    });
            }
        });
    }

    ngOnDestroy(): void {
        this.hubsService.disconnect();
    }

    add() {
        let modalRef = this.modalService.open(AddJournalEntryComponent, { size: 'lg' });
        modalRef.componentInstance.interventionId = this.journalDetail.intervention.id;
        modalRef.componentInstance.journalId = this.journalDetail.id;
    }


    exportToExcel() {
        let name = this.journalDetail.name || 'Combined';

        let workbook: ExcelProper.Workbook = new Excel.Workbook();
        let worksheet = workbook.addWorksheet(name);

        worksheet.getCell(1, 1).value = 'TEST';
        worksheet.getCell(1, 2).value = 'TEST';

        let row = 2;
        this.journalDetail.entries.forEach(x => {
            worksheet.getCell(row, 1).value = x.name;
            worksheet.getCell(row, 2).value = x.message;
            row++;
        });

        worksheet.autoFilter = {
            from: { row: 1, column: 1 },
            to: { row: row, column: 12 }
        };

        workbook.xlsx.writeBuffer().then((data) => {
            let blob = new Blob([data], { type: 'application/vnd.openxmlformats-officedocument.spreadsheetml.sheet' });
            fs.saveAs(blob, name + ".xlsx");
        });


    }
}
