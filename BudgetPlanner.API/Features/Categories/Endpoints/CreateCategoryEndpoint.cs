using BudgetPlanner.API.Data;
using BudgetPlanner.API.Features.Categories.Requests;
using BudgetPlanner.API.Features.Categories.Responses;
using BudgetPlanner.API.Interfaces;
using BudgetPlanner.API.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace BudgetPlanner.API.Features.Categories.Endpoints;

public sealed class CreateCategoryEndpoint : IEndpoint
{
    public static void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("/", HandleAsync);
    }

    public static async Task<Ok<CreateCategoryResponse>> HandleAsync(BudgetPlannerDbContext context,
                                                                     [FromBody] CreateCategoryRequest request)
    {
        Category category = new()
        {
            Id = Guid.NewGuid(),
            Name = request.Name
        };

        context.Categories.Add(category);
        await context.SaveChangesAsync();

        return TypedResults.Ok(new CreateCategoryResponse(category.Id, category.Name, 0, 0, 0));
    }
}