using BudgetPlanner.API.Data;
using BudgetPlanner.API.Features.Budget.Services;
using BudgetPlanner.API.Interfaces;
using BudgetPlanner.API.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace BudgetPlanner.API.Features.Budget.Endpoints;

public sealed class GetBudgetEndpoint : IEndpoint
{
    public static void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("/budget", HandleAsync);
    }

    /* maybe this should be more like a budget history?
    When a new month hits, create the budget for the old month */
    // or the moment a category is added then a new budget is created for that month
    private static async Task<Ok<MonthlyBudget>> HandleAsync(BudgetService budgetService)
    {
        var budget = await budgetService.TryGetCurrentMonthAsync();
        if (budget is null)
        {
            var newBudget = await budgetService.CreateBudgetAsync();
            return TypedResults.Ok(newBudget.Value);
        }
        return TypedResults.Ok(budget.Value);
    }
}
