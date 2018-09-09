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

    constructor(public activeModal: NgbActiveModal,
                private formBuilder: FormBuilder,
                private journalService: JournalService) {
        this.addForm = this.formBuilder.group({
            from: ['', Validators.required],
            date: [new Date(), Validators.required],
            text: ['', Validators.required],
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
            this.addForm.reset();
            return;
        }

        /*this.journalService.add(this.intervention.intervention.id, {
    id: 0,
    name: this.addForm.controls.name.value
}).subscribe(() => {
    this.addForm.reset();
});*/

        this.activeModal.close();
    }

}
