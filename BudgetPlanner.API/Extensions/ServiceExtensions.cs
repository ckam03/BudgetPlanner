using BudgetPlanner.API.Data;
using BudgetPlanner.API.Features.Budget;
using BudgetPlanner.API.Features.Categories;
using BudgetPlanner.API.Features.Expenses;
using BudgetPlanner.API.Features.Targets;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.EntityFrameworkCore;

namespace BudgetPlanner.API.Extensions;

public static class ServiceExtensions
{
    public static void RegisterServices(
        this IServiceCollection services,
        IConfiguration configuration
    )
    {
        var connectionString = configuration.GetConnectionString("FinancialManagementDb");
        services.AddDbContext<BudgetPlannerDbContext>(
            options => options.UseNpgsql(connectionString)
        );
        // services.AddDbContext<BudgetPlannerDbContext>(
        //     options => options.UseSqlServer(connectionString)
        // );
        services.AddTargetServices();
        services.AddExpenseServices();
        services.AddCategoryServices();
        services.AddBudgetServices();

        services.AddProblemDetails(options =>
        {
            options.CustomizeProblemDetails = (context) =>
            {
                context.ProblemDetails.Instance =
                    $"{context.HttpContext.Request.Method} {context.HttpContext.Request.Path}";
                context.ProblemDetails.Extensions.TryAdd(
                    "requestId",
                    context.HttpContext.TraceIdentifier
                );

                var activity = context.HttpContext.Features.Get<IHttpActivityFeature>()?.Activity;
                context.ProblemDetails.Extensions.TryAdd("traceId", activity?.Id);
            };
        });

        services.AddCors(options =>
        {
            options.AddDefaultPolicy(
                policyBuilder =>
                    policyBuilder
                        .WithOrigins("http://localhost:4200")
                        .AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader()
            );
        });
    }
}
