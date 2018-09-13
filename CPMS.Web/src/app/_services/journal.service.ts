import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { environment } from '../../environments/environment';
import { JournalDto } from "../_models/journalDto";
import { JournalDetailDto } from "../_models/journalDetailDto";
import { JournalEntryChannelDto } from "../_models/journalEntryChannelDto";
import { NewJournalEntryDto } from "../_models/newJournalEntryDto";
import { Cacheable } from "ngx-cacheable";

@Injectable()
export class JournalService {
    constructor(private http: HttpClient) {
    }

    @Cacheable()
    getChannels() {
        return this.http.get<JournalEntryChannelDto[]>(`${environment.apiUrl}/journals/Channels`);
    }

    getAllByIntervention(intervention: number) {
        return this.http.get<JournalDto[]>(`${environment.apiUrl}/journals/${intervention}`);
    }

    getJournalDetail(intervention: any, journal: any) {
        return this.http.get<JournalDetailDto>(`${environment.apiUrl}/Journals/Detail/${intervention}/${journal || 0}`);
    }

    add(interventionId: number, journal: JournalDto) {
        return this.http.put(`${environment.apiUrl}/Journals/${interventionId}`, journal);
    }

    addEntry(interventionId: number, journalId: number, newEntry: NewJournalEntryDto) {
        return this.http.put(`${environment.apiUrl}/Journals/AddEntry/${interventionId}/${journalId}`, newEntry);
    }
}
