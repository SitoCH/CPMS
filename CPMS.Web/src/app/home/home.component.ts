import { Component, OnInit } from '@angular/core';
import { first } from 'rxjs/operators';

import { UserService } from '../_services';
import {UserDto} from "../_models/userDto";

@Component({templateUrl: 'home.component.html'})
export class HomeComponent implements OnInit {
    currentUser: UserDto;
    users: UserDto[] = [];

    constructor(private userService: UserService) {
        this.currentUser = JSON.parse(localStorage.getItem('currentUser'));
    }

    ngOnInit() {
        this.loadAllUsers();
    }

    deleteUser(id: number) {
        this.userService.delete(id).pipe(first()).subscribe(() => { 
            this.loadAllUsers() 
        });
    }

    private loadAllUsers() {
        this.userService.getAll().pipe(first()).subscribe(users => { 
            this.users = users; 
        });
    }
}