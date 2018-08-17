import { Component, OnInit } from '@angular/core';
import { InterventionService } from "../_services/intervention.service";
import { InterventionDto } from "../_models/interventionDto";

@Component({
    selector: 'app-interventions',
    templateUrl: './interventions.component.html',
    styleUrls: ['./interventions.component.css']
})
export class InterventionsComponent implements OnInit {

    public interventions: InterventionDto[];

    constructor(private interventionService: InterventionService) {
    }

    ngOnInit() {

        this.interventionService.getInterventions().subscribe(interventions => {
            this.interventions = interventions;
        });

    }

}
