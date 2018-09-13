import { Component, OnInit } from '@angular/core';
import { NgbActiveModal, NgbModal } from "@ng-bootstrap/ng-bootstrap";
import { FormBuilder, FormGroup, Validators } from "@angular/forms";
import { JournalService } from "../../_services/journal.service";
import { JournalEntryChannelDto } from "../../_models/journalEntryChannelDto";

@Component({
    selector: 'app-add-journal-entry',
    templateUrl: './add-journal-entry.component.html',
    styleUrls: ['./add-journal-entry.component.css']
})
export class AddJournalEntryComponent implements OnInit {

    public addForm: FormGroup;
    public channels: JournalEntryChannelDto[];
    public interventionId: number;
    public journalId: number;

    constructor(public activeModal: NgbActiveModal,
                private formBuilder: FormBuilder,
                private journalService: JournalService) {

        let now = new Date();

        this.addForm = this.formBuilder.group({
            name: ['', Validators.required],
            date: [now, Validators.required],
            hours: [now.getHours(), [Validators.required, Validators.pattern(/^-?(0|[1-9]\d*)?$/)]],
            minutes: [now.getMinutes(), [Validators.required, Validators.pattern(/^-?(0|[1-9]\d*)?$/)]],
            message: ['', Validators.required],
            channel: [null, Validators.required],
            direction: [0, Validators.required]
        });
    }

    ngOnInit() {
        this.journalService.getChannels().subscribe(channels => {
            this.channels = channels;
        });
    }


    add() {
        if (this.addForm.invalid) {
            return;
        }

        let date: Date = this.addForm.controls.date.value;
        date.setHours(this.addForm.controls.hours.value);
        date.setMinutes(this.addForm.controls.minutes.value);

        this.journalService.addEntry(this.interventionId, this.journalId, {
            name: this.addForm.controls.name.value,
            dateTime: date,
            direction: this.addForm.controls.direction.value,
            journalEntryChannelId: this.addForm.controls.channel.value,
            message: this.addForm.controls.message.value
        }).subscribe(() => {
            this.activeModal.close();
        });

    }

}
