import { Component, OnDestroy, OnInit } from '@angular/core';
import { InterventionService } from "../_services/intervention.service";
import { ActivatedRoute, ParamMap, Router } from "@angular/router";
import { switchMap } from "rxjs/operators";
import { InterventionDetailDto } from "../_models/interventionDetailDto";
import { JournalService } from "../_services/journal.service";
import { JournalDto } from "../_models/journalDto";
import { NgbModal } from "@ng-bootstrap/ng-bootstrap";
import { HubsService } from "../_services/hubs.service";
import { FormBuilder, FormGroup, Validators } from "@angular/forms";

@Component({
    selector: 'intervention-detail',
    templateUrl: './intervention-detail.component.html',
    styleUrls: ['./intervention-detail.component.css']
})
export class InterventionDetailComponent implements OnInit, OnDestroy {

    public intervention: InterventionDetailDto;
    public journals: JournalDto[];
    public addForm: FormGroup;

    constructor(private interventionService: InterventionService,
                private route: ActivatedRoute,
                private journalService: JournalService,
                private modalService: NgbModal,
                private formBuilder: FormBuilder,
                private hubsService: HubsService) {
    }

    ngOnInit() {

        this.route.paramMap.pipe(
            switchMap((params: ParamMap) => {
                return this.interventionService.get(params.get('id'));
            }))
            .subscribe(intervention => {
                this.intervention = intervention;
                this.refreshJournals();

            });

        this.hubsService.connect();
        this.hubsService.journalUpdated.subscribe(event => {
            if (event.interventionId === this.intervention.intervention.id) {
                this.refreshJournals();
            }
        });

        this.addForm = this.formBuilder.group({
            name: ['', Validators.required]
        });

    }

    ngOnDestroy(): void {
        this.hubsService.disconnect();
    }

    private refreshJournals() {
        this.journalService.getAllByIntervention(this.intervention.intervention.id).subscribe(journals => {
            this.journals = journals;
        })
    }

    add(content) {
        this.modalService.open(content, {}).result.then(() => {
            if (this.addForm.invalid) {
                this.addForm.reset();
                return;
            }
            this.journalService.add(this.intervention.intervention.id, {
                id: 0,
                name: this.addForm.controls.name.value
            }).subscribe(() => {
                this.addForm.reset();
            });
        }, () => {
        });
    }
}
