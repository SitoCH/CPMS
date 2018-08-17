import { Component, OnInit } from '@angular/core';
import { InterventionService } from "../_services/intervention.service";
import { ActivatedRoute, ParamMap, Router } from "@angular/router";
import { switchMap } from "rxjs/operators";
import { InterventionDetailDto } from "../_models/interventionDetailDto";

@Component({
    selector: 'intervention-detail',
    templateUrl: './intervention-detail.component.html',
    styleUrls: ['./intervention-detail.component.css']
})
export class InterventionDetailComponent implements OnInit {

    public intervention: InterventionDetailDto;

    constructor(private interventionService: InterventionService,
                private route: ActivatedRoute) {
    }

    ngOnInit() {

        this.route.paramMap.pipe(
            switchMap((params: ParamMap) =>
                this.interventionService.getIntervention(params.get('id')))).subscribe(intervention => {
            this.intervention = intervention;
        });


    }

}
