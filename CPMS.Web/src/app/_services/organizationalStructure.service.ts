import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { environment } from '../../environments/environment';
import { DashboardDto } from "../_models/dashboardDto";
import { OrganizationalStructureDto } from "../_models/organizationalStructureDto";

@Injectable()
export class OrganizationalStructureService {
    constructor(private http: HttpClient) {
    }

    getOrganizationalStructure() {
        return this.http.get<OrganizationalStructureDto>(`${environment.apiUrl}/OrganizationalStructure`);
    }
}
