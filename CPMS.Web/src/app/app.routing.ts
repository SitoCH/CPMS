import { Routes, RouterModule } from '@angular/router';

import { HomeComponent } from './home';
import { LoginComponent } from './login';
import { AuthGuard } from './_helpers';
import { OrganizationalStructureComponent } from "./organizational-structure/organizational-structure.component";
import { InterventionsComponent } from "./interventions/interventions.component";
import { InterventionDetailComponent } from "./interventions/intervention-detail.component";

const appRoutes: Routes = [
    { path: '', component: HomeComponent, canActivate: [AuthGuard] },
    { path: 'login', component: LoginComponent },
    { path: 'organizational-structure', component: OrganizationalStructureComponent, canActivate: [AuthGuard] },
    { path: 'interventions', component: InterventionsComponent, canActivate: [AuthGuard] },
    { path: 'intervention/:id', component: InterventionDetailComponent, canActivate: [AuthGuard] },

    // otherwise redirect to home
    { path: '**', redirectTo: '' }
];

export const routing = RouterModule.forRoot(appRoutes);
