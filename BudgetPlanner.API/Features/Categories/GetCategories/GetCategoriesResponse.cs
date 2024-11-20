using BudgetPlanner.API.Features.Expenses.GetExpenses;

namespace BudgetPlanner.API.Features.Categories.GetCategories;

public sealed record GetCategoriesResponse(Guid Id,
                                           string Name,
                                           decimal TotalBudget,
                                           decimal TotalActivity,
                                           decimal TotalAvailable,
                                           List<GetExpensesResponse> Expenses);
