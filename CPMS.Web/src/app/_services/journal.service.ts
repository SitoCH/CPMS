import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { environment } from '../../environments/environment';
import { InterventionDto } from "../_models/interventionDto";
import { InterventionDetailDto } from "../_models/interventionDetailDto";
import { JournalDto } from "../_models/journalDto";
import { JournalDetailDto } from "../_models/journalDetailDto";
import { JournalEntryChannelDto } from "../_models/journalEntryChannelDto";

@Injectable()
export class JournalService {
    constructor(private http: HttpClient) {
    }

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
}
