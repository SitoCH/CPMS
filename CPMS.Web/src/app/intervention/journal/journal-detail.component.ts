import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, ParamMap } from "@angular/router";
import { JournalService } from "../../_services/journal.service";
import { switchMap } from "rxjs/operators";
import { JournalDetailDto } from "../../_models/journalDetailDto";

@Component({
    selector: 'app-journal-detail',
    templateUrl: './journal-detail.component.html',
    styleUrls: ['./journal-detail.component.css']
})
export class JournalDetailComponent implements OnInit {

    public journalDetail: JournalDetailDto;

    constructor(private route: ActivatedRoute,
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

}
