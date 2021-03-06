﻿import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS, HttpClient } from '@angular/common/http';

import { NgbDateAdapter, NgbDateNativeAdapter, NgbModule } from '@ng-bootstrap/ng-bootstrap';

import { AppComponent } from './app.component';
import { routing } from './app.routing';

import { AlertComponent } from './_directives';
import { AuthGuard, JwtInterceptor, ErrorInterceptor } from './_helpers';
import { AlertService, AuthenticationService, UserService, DashboardService } from './_services';
import { HomeComponent } from './home';
import { LoginComponent } from './login';

import { NavMenuComponent } from "./_directives/navmenu.component";

import { OrganizationalStructureComponent } from './organizational-structure/organizational-structure.component';

import { TranslateModule, TranslateLoader } from '@ngx-translate/core';
import { TranslateHttpLoader } from '@ngx-translate/http-loader';
import { OrganizationalStructureService } from "./_services/organizationalStructure.service";
import { GroupStructureComponent } from './organizational-structure/group-structure.component';
import { InterventionsComponent } from './intervention/interventions.component';
import { SidebarComponent } from './_directives/sidebar.component'
import { InterventionService } from "./_services/intervention.service";
import { InterventionDetailComponent } from './intervention/intervention-detail.component';
import { HubsService } from "./_services/hubs.service";
import { JournalService } from "./_services/journal.service";
import { JournalDetailComponent } from './intervention/journal/journal-detail.component';
import { QuillModule } from "ngx-quill";
import { AddJournalEntryComponent } from './intervention/journal/add-journal-entry.component'
import { ChannelCellComponent } from './intervention/journal/channel-cell.component'

export function HttpLoaderFactory(http: HttpClient) {
    return new TranslateHttpLoader(http, "/assets/i18n/", ".json");
}

@NgModule({
    imports: [
        BrowserModule,
        FormsModule,
        ReactiveFormsModule,
        HttpClientModule,
        routing,
        QuillModule,
        NgbModule.forRoot(),
        TranslateModule.forRoot({
            loader: {
                provide: TranslateLoader,
                useFactory: HttpLoaderFactory,
                deps: [HttpClient]
            }
        })
    ],
    declarations: [
        AppComponent,
        AlertComponent,
        HomeComponent,
        LoginComponent,
        NavMenuComponent,
        OrganizationalStructureComponent,
        GroupStructureComponent,
        InterventionsComponent,
        SidebarComponent,
        InterventionDetailComponent,
        JournalDetailComponent,
        AddJournalEntryComponent,
        ChannelCellComponent],
    providers: [
        AuthGuard,
        AlertService,
        AuthenticationService,
        UserService,
        DashboardService,
        InterventionService,
        OrganizationalStructureService,
        HubsService,
        JournalService,
        { provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true },
        { provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi: true },
        { provide: NgbDateAdapter, useClass: NgbDateNativeAdapter }
    ],
    entryComponents: [AddJournalEntryComponent],
    bootstrap: [AppComponent]
})

export class AppModule {
}
