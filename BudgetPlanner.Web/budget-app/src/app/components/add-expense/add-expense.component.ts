import { CommonModule } from '@angular/common';
import {
  Component,
  ElementRef,
  OnInit,
  signal,
  ViewChild,
  input,
} from '@angular/core';
import {
  FormControl,
  FormGroup,
  FormsModule,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { CreateExpense, Expense } from '../../models/expense';
import { ExpenseService } from '../../services/expense.service';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-add-expense',
  imports: [FormsModule, ReactiveFormsModule, CommonModule],
  templateUrl: './add-expense.component.html',
  styleUrl: './add-expense.component.css',
})
export class AddExpenseComponent {
  @ViewChild('myModal', { static: true })
  myModal!: ElementRef<HTMLDialogElement>;

  readonly categoryId = input.required<string>();

  expenseFormGroup = new FormGroup({
    expenseName: new FormControl('', Validators.required),
    budget: new FormControl('', Validators.required),
    availableAmount: new FormControl('', Validators.required),
    spentAmount: new FormControl('', Validators.required),
    dueDate: new FormControl('', Validators.required),
    recurring: new FormControl(false),
    occurrence: new FormControl(''),
  });

  private subscriptions = new Subscription();
  private expenseService: ExpenseService;

  constructor(expenseService: ExpenseService) {
    this.expenseService = expenseService;
  }

  openModal() {
    this.myModal.nativeElement.showModal();
    console.log(this.categoryId());
  }

  closeModal() {
    this.myModal.nativeElement.close();
  }

  submitExpense() {
    if (this.expenseFormGroup.valid) {
      const date = new Date(this.expenseFormGroup.value.dueDate as string);
      const expense: CreateExpense = {
        name: this.expenseFormGroup.value.expenseName as string,
        budget: Number(this.expenseFormGroup.value.budget),
        activity: Number(this.expenseFormGroup.value.availableAmount),
        available: Number(this.expenseFormGroup.value.spentAmount),
        isRecurring: this.expenseFormGroup.value.recurring as boolean,
        occurrence: this.expenseFormGroup.value.occurrence as string,
        date: {
          year: date.getFullYear(),
          month: date.getMonth(),
          day: date.getDate(),
        },
        id: this.categoryId(),
      };

      console.log(this.expenseFormGroup.value.recurring);

      const expenseSubscription = this.expenseService
        .addExpense(expense)
        .subscribe({
          next: (data) => {
            console.log(data);
            this.closeModal();
          },
          error: (error) => {
            console.error(error);
          },
        });
      this.subscriptions.add(expenseSubscription);
    }
  }
}
