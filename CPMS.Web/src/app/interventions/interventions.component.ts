import { Component, OnInit } from '@angular/core';
import { InterventionService } from "../_services/intervention.service";
import { InterventionDto } from "../_models/interventionDto";
import { NgbModal } from "@ng-bootstrap/ng-bootstrap";
import { FormBuilder, FormGroup, Validators } from "@angular/forms";

@Component({
    selector: 'app-interventions',
    templateUrl: './interventions.component.html',
    styleUrls: ['./interventions.component.css']
})
export class InterventionsComponent implements OnInit {

    public interventions: InterventionDto[];
    public addForm: FormGroup;

    constructor(private formBuilder: FormBuilder,
                private interventionService: InterventionService,
                private modalService: NgbModal) {
        this.addForm = this.formBuilder.group({
            name: ['', Validators.required]
        });
    }

    ngOnInit() {
        this.refreshInterventions();
    }

    private refreshInterventions() {
        this.interventionService.getAll().subscribe(interventions => {
            this.interventions = interventions;
        });
    }

    add(content) {
        this.modalService.open(content, {}).result.then(() => {
            if (this.addForm.invalid) {
                return;
            }
            this.interventionService.add({
                id: 0,
                name: this.addForm.controls.name.value
            }).subscribe(() => {
                this.refreshInterventions();
            });
        });
    }

}
