import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { DashboardData } from '../models/dashboard-data';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { categoryId } from '../models/category-ids';

@Injectable({
  providedIn: 'root',
})
export class DashboardService {
  constructor(private httpClient: HttpClient) {}

  getTableData(): Observable<any> {
    const headers = new HttpHeaders({
      'Content-Type': 'application/json',
      mode: 'cors',
    });
    return this.httpClient.get<any>('http://localhost:5204/category');
  }

  createCategory(category: string): Observable<DashboardData> {
    const headers = new HttpHeaders({
      'Content-Type': 'application/json',
      mode: 'cors',
    });
    return this.httpClient.post<DashboardData>(
      'http://localhost:5204/category',
      { name: category },
      { headers }
    );
  }

  deleteCategory(categoryIds: string[]): Observable<string[]> {
    const headers = new HttpHeaders({
      'Content-Type': 'application/json',
      mode: 'cors',
    });
    return this.httpClient.delete<string[]>(`http://localhost:5204/category`, {
      body: { ids: categoryIds },
      headers,
    });
  }
}
