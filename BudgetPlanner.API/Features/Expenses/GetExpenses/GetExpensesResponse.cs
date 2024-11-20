using BudgetPlanner.API.Models;

namespace BudgetPlanner.API.Features.Expenses.GetExpenses;

public sealed record GetExpensesResponse(Guid Id,
                                         string Name,
                                         decimal Budget,
                                         decimal Activity,
                                         decimal Available,
                                         Recurrence Occurrence,
                                         DateOnly? Date);
