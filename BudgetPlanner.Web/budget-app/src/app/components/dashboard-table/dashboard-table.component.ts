import { Component, computed, OnDestroy, OnInit, signal } from '@angular/core';
import { DashboardService } from '../../services/dashboard.service';
import { Subscription } from 'rxjs';
import { DashboardData } from '../../models/dashboard-data';
import {
  LucideAngularModule,
  PlusCircleIcon,
  Trash2Icon,
  ChevronDownIcon,
  PlusIcon,
} from 'lucide-angular';
import { CommonModule } from '@angular/common';
import { AddExpenseComponent } from '../add-expense/add-expense.component';

@Component({
    selector: 'app-dashboard-table',
    imports: [LucideAngularModule, CommonModule, AddExpenseComponent],
    templateUrl: './dashboard-table.component.html',
    styleUrl: './dashboard-table.component.css'
})
export class DashboardTableComponent implements OnInit, OnDestroy {
  private subscriptions = new Subscription();
  public categoryInput: string = '';
  public tableData = signal<DashboardData[]>([]);
  public expandedCategories = signal<Record<string, boolean>>({});
  public ids = signal<string[]>([]);
  readonly PlusCircleIcon = PlusCircleIcon;
  readonly Trash2Icon = Trash2Icon;
  readonly ChevronDownIcon = ChevronDownIcon;
  readonly PlusIcon = PlusIcon;

  constructor(private dashboardService: DashboardService) {}

  ngOnInit() {
    this.getTableData();
  }

  ngOnDestroy() {
    this.subscriptions.unsubscribe();
  }

  getTableData() {
    const tableDataSubscription = this.dashboardService
      .getTableData()
      .subscribe({
        next: (data) => {
          this.tableData.set(data);
          console.log(data);
        },
        error: (error) => {
          console.error(error);
        },
      });
    this.subscriptions.add(tableDataSubscription);
  }

  createCategory(category: string): void {
    const categorySubscription = this.dashboardService
      .createCategory(category)
      .subscribe({
        next: (data) => {
          const updateTableData = computed(() => this.tableData().push(data));
          updateTableData();
          this.sortTableData();
        },
        error: (error) => {
          console.error(error);
        },
      });
    this.subscriptions.add(categorySubscription);
  }

  updateCategories(data: any) {
    const updateTableData = computed(() => this.tableData().push(data));
    updateTableData();
  }

  toggleCheckbox(id: string, event: Event) {
    const checkbox = event.target as HTMLInputElement;

    if (checkbox.checked) {
      this.ids.update((currentIds: string[]) => [...currentIds, id]);
    } else {
      this.ids.update((ids) => ids.filter((i) => i !== id));
    }

    console.log(this.ids());
  }

  //todo: is this a use case for lazy loading?
  toggleExpenses(id: string, event: Event) {
    const checkbox = event.target as HTMLInputElement;

    this.expandedCategories.update((current) => {
      return { ...current, [id]: checkbox.checked };
    });
  }

  deleteCategory() {
    const deleteCategorySubscription = this.dashboardService
      .deleteCategory(this.ids())
      .subscribe({
        next: (data) => {
          const ids = Object.values(data)[0];
          this.tableData.update((data) =>
            data.filter((d) => !ids.includes(d.id))
          );
          this.ids.set([]);
        },
        error: (error) => {
          console.error(error);
        },
      });
    this.subscriptions.add(deleteCategorySubscription);
  }

  sortTableData(): void {
    this.tableData().sort((a, b) => a.name.localeCompare(b.name));
  }
}
