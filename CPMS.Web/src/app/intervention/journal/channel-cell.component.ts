import { Component, Input, OnInit } from '@angular/core';
import { JournalService } from "../../_services/journal.service";

@Component({
    selector: 'channel-cell',
    templateUrl: './channel-cell.component.html'
})
export class ChannelCellComponent implements OnInit {

    @Input() channelId: number;
    channelIcon: string;
    channelName: string;

    constructor(private journalService: JournalService) {
    }

    ngOnInit() {
        this.journalService.getChannels().subscribe(channels => {
            let channel = channels.find(x => x.id == this.channelId);
            this.channelIcon = channel.icon;
            this.channelName = channel.name;
        });
    }

}
