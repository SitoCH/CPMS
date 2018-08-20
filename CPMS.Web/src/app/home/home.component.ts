import { Component, OnDestroy, OnInit } from '@angular/core';

import { UserDto } from "../_models/userDto";
import { DashboardService } from "../_services";
import { DashboardDto } from "../_models/dashboardDto";
import { HubsService } from "../_services/hubs.service";

@Component({ templateUrl: 'home.component.html' })
export class HomeComponent implements OnInit, OnDestroy {
    currentUser: UserDto;
    dashboardDto: DashboardDto;

    constructor(private dashboardService: DashboardService,
                private hubsService: HubsService) {
        this.currentUser = JSON.parse(localStorage.getItem('currentUser'));
    }

    ngOnInit() {
        this.loadDashboard();
        this.hubsService.connect();
        this.hubsService.interventionUpdated.subscribe(id => {
            this.loadDashboard();
        });
    }

    ngOnDestroy(): void {
        this.hubsService.disconnect();
    }

    private loadDashboard() {
        this.dashboardService.getDashboard().subscribe(dashboardDto => {
            this.dashboardDto = dashboardDto;
        });
    }


}
