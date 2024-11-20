export interface Expense {
  name: string;
  budget: number;
  activity: number;
  available: number;
  isRecurring: boolean;
  occurrence: string;
  date: {
    year: number;
    month: number;
    day: number;
  };
  id: string;
}
