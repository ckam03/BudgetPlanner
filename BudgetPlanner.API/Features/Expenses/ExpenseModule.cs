using BudgetPlanner.API.Features.Expenses.Endpoints;
using BudgetPlanner.API.Features.Expenses.Services;

namespace BudgetPlanner.API.Features.Expenses;

public static class ExpenseModule
{
    public static void AddExpenseServices(this IServiceCollection services)
    {
        services.AddScoped<ExpenseService>();
    }

    public static void MapExpenseEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/expenses");

        CreateExpenseEndpoint.MapEndpoint(group);
        EditExpenseEndpoint.MapEndpoint(group);
    }
}
