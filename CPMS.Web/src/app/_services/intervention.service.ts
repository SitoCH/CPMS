import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { environment } from '../../environments/environment';
import { InterventionDto } from "../_models/interventionDto";
import { InterventionDetailDto } from "../_models/interventionDetailDto";

@Injectable()
export class InterventionService {
    constructor(private http: HttpClient) {
    }

    getInterventions() {
        return this.http.get<InterventionDto[]>(`${environment.apiUrl}/interventions`);
    }

    getIntervention(id: any) {
        return this.http.get<InterventionDetailDto>(`${environment.apiUrl}/interventions/${id}`);
    }
}
