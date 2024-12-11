using BudgetPlanner.API.Extensions;
using BudgetPlanner.API.Features.Expenses.Endpoints;

namespace BudgetPlanner.API.Features.Expenses;

public static class ExpenseEndpoints
{
    public static void MapExpenseEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/expenses");

        group.MapEndpoint<CreateExpenseEndpoint>();
        group.MapEndpoint<EditExpenseEndpoint>();
    }
}
