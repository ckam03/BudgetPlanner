import { Component } from '@angular/core';
import { FundsTrackerComponent } from '../funds-tracker/funds-tracker.component';
import { CategoryInfoComponent } from '../category-info/category-info.component';
import { DashboardTableComponent } from '../dashboard-table/dashboard-table.component';

@Component({
    selector: 'app-home',
    imports: [
        FundsTrackerComponent,
        CategoryInfoComponent,
        DashboardTableComponent,
    ],
    templateUrl: './home.component.html',
    styleUrl: './home.component.css'
})
export class HomeComponent {}
