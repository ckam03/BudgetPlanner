using BudgetPlanner.API.Features.Budget.Services;
using BudgetPlanner.API.Interfaces;
using BudgetPlanner.API.Models;
using Microsoft.AspNetCore.Http.HttpResults;

namespace BudgetPlanner.API.Features.Budget.Endpoints;

public class CreateBudgetEndpoint : IEndpoint
{
    public static void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("/", HandleAsync);
    }

    private static async Task<Results<Ok<MonthlyBudget>, ProblemHttpResult>> HandleAsync(
        BudgetService budgetService
    )
    {
        var budget = await budgetService.GetOrCreateBudgetAsync();

        if (!budget.IsSuccess)
        {
            return TypedResults.Problem(
                detail: budget.Error,
                statusCode: StatusCodes.Status400BadRequest,
                title: "Invalid Budget month"
            );
        }

        return TypedResults.Ok(budget.Value);
    }
}
