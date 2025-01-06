import { Component } from '@angular/core';
import { FundsTrackerComponent } from '../funds-tracker/funds-tracker.component';
import { CategoryInfoComponent } from '../category-info/category-info.component';
import { DashboardTableComponent } from '../dashboard-table/dashboard-table.component';
import { TargetComponent } from '../target/target.component';
import { MonthComponent } from '../month/month.component';

@Component({
  selector: 'app-home',
  imports: [
    FundsTrackerComponent,
    CategoryInfoComponent,
    DashboardTableComponent,
    MonthComponent,
  ],
  templateUrl: './home.component.html',
  styleUrl: './home.component.css',
})
export class HomeComponent {}
