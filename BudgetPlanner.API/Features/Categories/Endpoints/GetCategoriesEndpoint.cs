using BudgetPlanner.API.Data;
using BudgetPlanner.API.Features.Categories.Responses;
using BudgetPlanner.API.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace BudgetPlanner.API.Features.Categories.Endpoints;

public sealed class GetCategoriesEndpoint : IEndpoint
{
    public static void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("/", HandleAsync);
    }

    public static async Task<Ok<List<GetCategoriesResponse>>> HandleAsync(BudgetPlannerDbContext context)
    {
        List<GetCategoriesResponse> response = await context.Categories
            .Select(CategoryMappings.ToGetCategoriesResponse)
            .ToListAsync();

        return TypedResults.Ok(response);
    }
}
