namespace BudgetPlanner.API.Features.Categories.Responses;

public sealed record CreateCategoryResponse(Guid Id,
                                            string Name,
                                            decimal TotalBudget,
                                            decimal TotalActivity,
                                            decimal TotalAvailable);
