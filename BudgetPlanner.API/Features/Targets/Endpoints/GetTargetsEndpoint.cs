using BudgetPlanner.API.Data;
using BudgetPlanner.API.Interfaces;

namespace BudgetPlanner.API.Features.Targets.Endpoints;

public sealed class GetTargetsEndpoint : IEndpoint
{
    public static void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("/targets", HandleAsync);
    }

    private static async Task HandleAsync(BudgetPlannerDbContext context)
    {
        throw new NotImplementedException();
    }
}
