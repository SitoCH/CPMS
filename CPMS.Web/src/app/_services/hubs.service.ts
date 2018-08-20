import { EventEmitter, Injectable } from '@angular/core';
import * as signalR from "@aspnet/signalr";
import { environment } from "../../environments/environment";

@Injectable()
export class HubsService {

    public interventionUpdated = new EventEmitter<number>();
    private connection: signalR.HubConnection;

    connect() {
        if (!this.connection) {
            this.connection = new signalR.HubConnectionBuilder()
                .withUrl(`${environment.apiUrl}/hubs/intervention`, {})
                .build();

            this.connection.on("interventionUpdated", (id) => {
                this.interventionUpdated.emit(id);
            });

            this.connection.start().catch(err => console.error(err));
        }
    }

    disconnect() {
        if (this.connection) {
            this.connection.stop();
            this.connection = null;
        }
    }

}
