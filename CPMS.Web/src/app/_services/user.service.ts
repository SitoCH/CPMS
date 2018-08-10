import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { environment } from '../../environments/environment';
import {UserDto} from "../_models/userDto";

@Injectable()
export class UserService {
    constructor(private http: HttpClient) { }

    getAll() {
        return this.http.get<UserDto[]>(`${environment.apiUrl}/users`);
    }

    getById(id: number) {
        return this.http.get(`${environment.apiUrl}/users/` + id);
    }

    update(user: UserDto) {
        return this.http.put(`${environment.apiUrl}/users/` + user.id, user);
    }

    delete(id: number) {
        return this.http.delete(`${environment.apiUrl}/users/` + id);
    }
}