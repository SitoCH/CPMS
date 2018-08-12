import {Component, OnInit} from '@angular/core';

import {UserDto} from "../_models/userDto";
import {DashboardService} from "../_services";
import {DashboardDto} from "../_models/dashboardDto";

@Component({templateUrl: 'home.component.html'})
export class HomeComponent implements OnInit {
    currentUser: UserDto;
    dashboardDto: DashboardDto

    constructor(private dashboardService: DashboardService) {
        this.currentUser = JSON.parse(localStorage.getItem('currentUser'));
    }

    ngOnInit() {
        this.loadDashboard();
    }

    private loadDashboard() {
        this.dashboardService.getDashboard().subscribe(dashboardDto => {
            this.dashboardDto = dashboardDto;
        });
    }
}
