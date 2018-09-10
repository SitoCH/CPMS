import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, ParamMap } from "@angular/router";
import { JournalService } from "../../_services/journal.service";
import { switchMap } from "rxjs/operators";
import { JournalDetailDto } from "../../_models/journalDetailDto";
import { JournalEntryDto } from "../../_models/journalEntryDto";
import { NgbModal } from "@ng-bootstrap/ng-bootstrap";
import { FormBuilder, FormGroup, Validators } from "@angular/forms";
import { AddJournalEntryComponent } from "./add-journal-entry.component";

@Component({
    selector: 'app-journal-detail',
    templateUrl: './journal-detail.component.html',
    styleUrls: ['./journal-detail.component.css']
})
export class JournalDetailComponent implements OnInit {

    public journalDetail: JournalDetailDto;

    constructor(private route: ActivatedRoute,
                private modalService: NgbModal,
                private journalService: JournalService) {
    }

    ngOnInit() {
        this.route.paramMap.pipe(
            switchMap((params: ParamMap) => {
                return this.journalService.getJournalDetail(params.get('interventionId'), params.get('journalId'));
            }))
            .subscribe(journalDetail => {
                this.journalDetail = journalDetail;
            });
    }

    add() {
        this.modalService.open(AddJournalEntryComponent, {size: 'lg'});
    }
}
