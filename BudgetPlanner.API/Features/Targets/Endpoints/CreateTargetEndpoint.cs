using BudgetPlanner.API.Features.Targets.Services;
using BudgetPlanner.API.Interfaces;

namespace BudgetPlanner.API.Features.Targets.Endpoints;

public sealed class CreateTargetEndpoint : IEndpoint
{
    public static void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("/api/targets", HandleAsync).WithDescription("Creates a new expense target.");
    }

    private static async Task HandleAsync(ITargetService targetService, CreateTargetRequest request)
    {
        await targetService.CreateTargetAsync(request.Target);
    }
}

public sealed record CreateTargetRequest(string Target);
