import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { environment } from '../../environments/environment';
import { InterventionDto } from "../_models/interventionDto";
import { InterventionDetailDto } from "../_models/interventionDetailDto";
import { JournalDto } from "../_models/journalDto";

@Injectable()
export class JournalService {
    constructor(private http: HttpClient) {
    }

    getAllByIntervention(intervention: number) {
        return this.http.get<JournalDto[]>(`${environment.apiUrl}/journals/${intervention}`);
    }

}
