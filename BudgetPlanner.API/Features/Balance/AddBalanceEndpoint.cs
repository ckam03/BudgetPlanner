using BudgetPlanner.API.Data;
using BudgetPlanner.API.Interfaces;

namespace BudgetPlanner.API.Features.Balance;

public class AddBalanceEndpoint : IEndpoint
{
    public static void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("/balance", HandleAsync);
    }

    private static async Task HandleAsync(BudgetPlannerDbContext context) { }
}

public sealed record AddBalanceRequest(decimal Amount);
