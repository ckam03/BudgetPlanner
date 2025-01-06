using BudgetPlanner.API.Data;
using BudgetPlanner.API.Features.Categories.Requests;
using BudgetPlanner.API.Features.Categories.Responses;
using BudgetPlanner.API.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BudgetPlanner.API.Features.Categories.Endpoints;

public sealed class DeleteCategoryEndpoint : IEndpoint
{
    public static void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapDelete("/", HandleAsync);
    }

    public static async Task<DeleteCategoryResponse> HandleAsync(
        BudgetPlannerDbContext context,
        [FromBody] DeleteCategoryRequest request
    )
    {
        var items = await context.Categories
            .Where(category => request.Ids.Contains(category.Id))
            .ExecuteDeleteAsync();

        await context.SaveChangesAsync();
        return new DeleteCategoryResponse(request.Ids);
    }
}
