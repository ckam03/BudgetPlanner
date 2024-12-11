using BudgetPlanner.API.Models;

namespace BudgetPlanner.API.Features.Expenses.Responses;

public sealed record GetExpensesResponse(Guid Id,
                                         string Name,
                                         decimal Budget,
                                         decimal Activity,
                                         decimal Available,
                                         string Occurrence,
                                         bool IsRecurring,
                                         DateOnly? Date);
