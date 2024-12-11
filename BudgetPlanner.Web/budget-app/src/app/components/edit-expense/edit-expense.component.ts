import { CommonModule } from '@angular/common';
import { Component, ElementRef, Input, OnInit, ViewChild } from '@angular/core';
import {
  FormControl,
  FormGroup,
  FormsModule,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { Expense } from '../../models/expense';

@Component({
  selector: 'app-edit-expense',
  imports: [FormsModule, ReactiveFormsModule, CommonModule],
  templateUrl: './edit-expense.component.html',
  styleUrl: './edit-expense.component.css',
})
export class EditExpenseComponent implements OnInit {
  ngOnInit() {
    if (this.expense) {
      this.expenseFormGroup.patchValue({
        expenseName: this.expense.name,
        budget: this.expense.budget,
        availableAmount: this.expense.available,
        spentAmount: this.expense.activity,
        dueDate: this.expense.date,
        recurring: this.expense.isRecurring,
        occurrence: this.expense.occurrence,
      });
    }
    console.log(this.expense.occurrence);
  }
  @ViewChild('expenseModal', { static: true })
  expenseModal!: ElementRef<HTMLDialogElement>;

  @Input() expense!: Expense;

  expenseFormGroup = new FormGroup({
    expenseName: new FormControl('', Validators.required),
    budget: new FormControl(0, Validators.required),
    availableAmount: new FormControl(0, Validators.required),
    spentAmount: new FormControl(0, Validators.required),
    dueDate: new FormControl(new Date(), Validators.required),
    recurring: new FormControl(false),
    occurrence: new FormControl(''),
  });

  openModal() {
    this.expenseModal.nativeElement.showModal();
    console.log('open');
  }

  editExpense() {
    console.log(this.expenseFormGroup.value);
  }
}
