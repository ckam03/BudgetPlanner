using BudgetPlanner.API.Features.Categories;
using BudgetPlanner.API.Features.Expenses;
using BudgetPlanner.API.Interfaces;

namespace BudgetPlanner.API.Extensions;

public static class EndpointExtensions
{
    public static void MapEndpoints(this WebApplication app)
    {
        app.MapExpenseEndpoints();
        app.MapCategoryEndpoints();
    }

    public static IEndpointRouteBuilder MapEndpoint<T>(this IEndpointRouteBuilder app) where T : IEndpoint
    {
        T.MapEndpoint(app);
        return app;
    }
}
