import {
  Component,
  EventEmitter,
  inject,
  OnDestroy,
  Output,
  signal,
} from '@angular/core';
import { LucideAngularModule, PlusCircleIcon } from 'lucide-angular';
import { DashboardService } from '../../services/dashboard.service';
import { Subscription } from 'rxjs';
import {
  FormControl,
  FormGroup,
  FormsModule,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { DashboardData } from '../../models/dashboard-data';

@Component({
  selector: 'app-add-category',
  standalone: true,
  imports: [LucideAngularModule, FormsModule, ReactiveFormsModule],
  templateUrl: './add-category.component.html',
  styleUrl: './add-category.component.css',
})
export class AddCategoryComponent implements OnDestroy {
  dashboardService = inject(DashboardService);

  categoryGroup = new FormGroup({
    categoryInput: new FormControl('', Validators.required),
  });

  //public tableData = signal<DashboardData[]>([]);
  @Output() newCategory = new EventEmitter<DashboardData>();
  private subscriptions = new Subscription();
  readonly PlusCircleIcon = PlusCircleIcon;

  ngOnDestroy(): void {
    this.subscriptions.unsubscribe();
  }

  createCategory(): void {
    let category = this.categoryGroup.controls.categoryInput.value as string;
    const categorySubscription = this.dashboardService
      .createCategory(category)
      .subscribe({
        next: (data) => {
          this.updateCategories(data);
          // this.sortTableData();
        },
        error: (error) => {
          console.error(error);
        },
      });
    this.subscriptions.add(categorySubscription);
  }

  updateCategories(data: DashboardData) {
    this.newCategory.emit(data);
  }
}
