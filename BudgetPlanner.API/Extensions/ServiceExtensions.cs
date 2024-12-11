using BudgetPlanner.API.Data;
using BudgetPlanner.API.Features.Targets;
using Microsoft.EntityFrameworkCore;

namespace BudgetPlanner.API.Extensions;

public static class ServiceExtensions
{
    public static void AddServices(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("FinancialManagementDb");

        services.AddDbContext<BudgetPlannerDbContext>(options => options.UseSqlServer(connectionString));
        services.AddTargetServices();
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));
        services.AddCors(options =>
        {
            options.AddDefaultPolicy(
                policyBuilder => policyBuilder.WithOrigins("http://localhost:4200")
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
        });
    }
}
