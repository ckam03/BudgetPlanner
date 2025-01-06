using BudgetPlanner.API.Features.Budget;
using BudgetPlanner.API.Features.Categories;
using BudgetPlanner.API.Features.Expenses;

namespace BudgetPlanner.API.Extensions;

public static class EndpointExtensions
{
    public static void MapEndpoints(this WebApplication app)
    {
        app.MapExpenseEndpoints();
        app.MapCategoryEndpoints();
        app.MapBudgetEndpoints();
    }
}
