import { Expense } from './expense';

export type DashboardData = {
  id: string;
  name: string;
  totalBudget: number;
  totalActivity: number;
  totalAvailable: number;
  expenses: Expense[];
};
