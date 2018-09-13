import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { environment } from '../../environments/environment';
import { InterventionDto } from "../_models/interventionDto";

@Injectable()
export class InterventionService {
    constructor(private http: HttpClient) {
    }

    getAll() {
        return this.http.get<InterventionDto[]>(`${environment.apiUrl}/interventions`);
    }

    get(id: any) {
        return this.http.get<InterventionDto>(`${environment.apiUrl}/interventions/${id}`);
    }

    add(intervention: InterventionDto) {
        return this.http.put(`${environment.apiUrl}/interventions`, intervention);
    }
}
