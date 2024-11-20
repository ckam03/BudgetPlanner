namespace BudgetPlanner.API.Features.Categories.CreateCategory;

public sealed record CreateCategoryResponse(Guid Id,
                                            string Name,
                                            decimal TotalBudget,
                                            decimal TotalActivity,
                                            decimal TotalAvailable);
