import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { environment } from '../../environments/environment';
import { DashboardDto } from "../_models/dashboardDto";

@Injectable()
export class DashboardService {
    constructor(private http: HttpClient) {
    }

    getDashboard() {
        return this.http.get<DashboardDto>(`${environment.apiUrl}/dashboard`);
    }
}
