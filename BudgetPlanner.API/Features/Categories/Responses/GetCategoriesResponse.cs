using BudgetPlanner.API.Features.Expenses.Responses;

namespace BudgetPlanner.API.Features.Categories.Responses;

public sealed record GetCategoriesResponse(Guid Id,
                                           string Name,
                                           decimal TotalBudget,
                                           decimal TotalActivity,
                                           decimal TotalAvailable,
                                           List<GetExpensesResponse> Expenses);