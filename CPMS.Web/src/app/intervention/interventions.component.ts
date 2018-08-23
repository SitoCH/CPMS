import { Component, OnDestroy, OnInit } from '@angular/core';
import { InterventionService } from "../_services/intervention.service";
import { InterventionDto } from "../_models/interventionDto";
import { NgbModal } from "@ng-bootstrap/ng-bootstrap";
import { FormBuilder, FormGroup, Validators } from "@angular/forms";
import { HubsService } from "../_services/hubs.service";

@Component({
    selector: 'app-interventions',
    templateUrl: './interventions.component.html',
    styleUrls: ['./interventions.component.css']
})
export class InterventionsComponent implements OnInit, OnDestroy {

    public interventions: InterventionDto[];
    public addForm: FormGroup;

    constructor(private formBuilder: FormBuilder,
                private interventionService: InterventionService,
                private modalService: NgbModal,
                private hubsService: HubsService) {

        this.addForm = this.formBuilder.group({
            name: ['', Validators.required]
        });
    }

    ngOnInit() {
        this.refreshInterventions();
        this.hubsService.connect();
        this.hubsService.interventionUpdated.subscribe(id => {
            this.refreshInterventions();
        });
    }

    ngOnDestroy(): void {
        this.hubsService.disconnect();
    }

    private refreshInterventions() {
        this.interventionService.getAll().subscribe(interventions => {
            this.interventions = interventions;
        });
    }

    add(content) {
        this.modalService.open(content, {}).result.then(() => {
            if (this.addForm.invalid) {
                this.addForm.reset();
                return;
            }
            this.interventionService.add({
                id: 0,
                name: this.addForm.controls.name.value
            }).subscribe(() => {
                this.addForm.reset();
            });
        }, () => {
        });
    }
}
