using BudgetPlanner.API.Features.Budget.Endpoints;
using BudgetPlanner.API.Features.Budget.Services;

namespace BudgetPlanner.API.Features.Budget
{
    public static class BudgetModule
    {
        public static void AddBudgetServices(this IServiceCollection services)
        {
            services.AddScoped<BudgetService>();
        }

        public static void MapBudgetEndpoints(this IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("/budget");
            CreateBudgetEndpoint.MapEndpoint(group);
        }
    }
}
