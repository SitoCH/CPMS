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

    constructor(private route: ActivatedRoute,
                private modalService: NgbModal,
                private journalService: JournalService,
                private hubsService: HubsService) {
    }

    ngOnInit() {
        this.route.paramMap.pipe(
            switchMap((params: ParamMap) => {
                return this.journalService.getJournalDetail(params.get('interventionId'), params.get('journalId'));
            }))
            .subscribe(journalDetail => {
                this.journalDetail = journalDetail;
            });

        this.hubsService.connect();
        this.hubsService.journalUpdated.subscribe(event => {
            if (this.journalDetail && event.journalId === this.journalDetail.id) {
                this.journalService.getJournalDetail(event.interventionId, event.journalId)
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
