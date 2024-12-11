import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { CreateExpense, Expense } from '../models/expense';

@Injectable({
  providedIn: 'root',
})
export class ExpenseService {
  constructor(private httpClient: HttpClient) {}

  addExpense(expense: CreateExpense) {
    console.log(expense);
    const headers = new HttpHeaders({
      'Content-Type': 'application/json',
    });
    return this.httpClient.post<any>(
      'http://localhost:5204/expenses',
      expense,
      { headers }
    );
  }

  deleteExpense() {}
}
