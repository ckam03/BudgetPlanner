namespace BudgetPlanner.API.Features.Balance;

public static class BalanceModule
{
    public static void AddServices(IServiceCollection services) { }

    public static void MapEndpoints(IEndpointRouteBuilder app)
    {
        AddBalanceEndpoint.MapEndpoint(app);
    }
}
