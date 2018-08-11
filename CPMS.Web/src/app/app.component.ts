import {Component, OnDestroy, OnInit} from '@angular/core';
import {ActivatedRoute, NavigationEnd, Router} from "@angular/router";
import {Subscription} from "rxjs";

@Component({
    selector: 'app',
    templateUrl: 'app.component.html'
})

export class AppComponent implements OnInit, OnDestroy {

    subscription: Subscription;

    showNavBars: boolean;

    constructor(private router: Router) {

    }

    ngOnInit() {
        this.subscription = this.router.events.subscribe(event => {
            if (event instanceof NavigationEnd) {
                this.showNavBars = !event.url.startsWith('/login');
            }
        });
    }

    ngOnDestroy() {
        this.subscription.unsubscribe();
    }
}