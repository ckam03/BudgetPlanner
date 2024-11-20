using System;

namespace BudgetPlanner.API.Features.Expenses.CreateExpense;

public record ExpenseResponse(string Name,
                              decimal Budget,
                              decimal Activity,
                              decimal Available,
                              string Recurrence,
                              DateOnly? Date);
