using BudgetPlanner.API.Features.Targets.Services;

namespace BudgetPlanner.API.Features.Targets;

public static class TargetModule
{
    public static void AddTargetServices(this IServiceCollection services)
    {
        services.AddScoped<ITargetService, TargetService>();
    }

    public static void MapTargetEndpoints(this IEndpointRouteBuilder app)
    {

    }
}
