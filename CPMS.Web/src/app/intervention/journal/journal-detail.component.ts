import { Component, OnDestroy, OnInit } from '@angular/core';
import { ActivatedRoute, ParamMap } from "@angular/router";
import { JournalService } from "../../_services/journal.service";
import { switchMap } from "rxjs/operators";
import { JournalDetailDto } from "../../_models/journalDetailDto";
import { JournalEntryDto } from "../../_models/journalEntryDto";
import { NgbModal } from "@ng-bootstrap/ng-bootstrap";
import { FormBuilder, FormGroup, Validators } from "@angular/forms";
import { AddJournalEntryComponent } from "./add-journal-entry.component";
import { HubsService } from "../../_services/hubs.service";

@Component({
    selector: 'app-journal-detail',
    templateUrl: './journal-detail.component.html',
    styleUrls: ['./journal-detail.component.css']
})
export class JournalDetailComponent implements OnInit, OnDestroy {

    public journalDetail: JournalDetailDto;
    public isCombinedJournal: boolean;

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
        this.route.paramMap.pipe(
            switchMap((params: ParamMap) => {
                return this.journalService.getJournalDetail(params.get('interventionId'), params.get('journalId'));
            }))
            .subscribe(journalDetail => {
                this.journalDetail = journalDetail;
                this.isCombinedJournal = journalDetail.id == 0;
            });

        this.hubsService.connect();
        this.hubsService.journalUpdated.subscribe(event => {
            if (this.journalDetail && this.shouldRefresh(event.interventionId, event.journalId)) {
                this.journalService.getJournalDetail(event.interventionId, this.isCombinedJournal ? 0 : event.journalId)
                    .subscribe(journalDetail => {
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
}
