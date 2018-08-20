import { Component, OnInit } from '@angular/core';
import { InterventionService } from "../_services/intervention.service";
import { ActivatedRoute, ParamMap, Router } from "@angular/router";
import { switchMap } from "rxjs/operators";
import { InterventionDetailDto } from "../_models/interventionDetailDto";
import { JournalService } from "../_services/journal.service";
import { JournalDto } from "../_models/journalDto";

@Component({
    selector: 'intervention-detail',
    templateUrl: './intervention-detail.component.html',
    styleUrls: ['./intervention-detail.component.css']
})
export class InterventionDetailComponent implements OnInit {

    public intervention: InterventionDetailDto;
    public journals: JournalDto[];

    constructor(private interventionService: InterventionService,
                private route: ActivatedRoute,
                private journalService: JournalService) {
    }

    ngOnInit() {

        this.route.paramMap.pipe(
            switchMap((params: ParamMap) => {
                return this.interventionService.get(params.get('id'));
            }))
            .subscribe(intervention => {
                this.intervention = intervention;
                this.journalService.getAllByIntervention(intervention.intervention.id).subscribe(journals => {
                    this.journals = journals;
                })
            });


    }

}
