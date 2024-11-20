using BudgetPlanner.API.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BudgetPlanner.API.Features.Categories.CreateCategory;

public class CreateCategoryEndpoint : IEndpoint
{
    public void MapEndpoint(WebApplication app)
    {
        app.MapPost("/category", async (IMediator mediator, [FromBody] CreateCategoryRequest request) =>
        {
            CreateCategoryResponse result = await mediator.Send(new CreateCategoryCommand(request.Name));
            return TypedResults.Ok(result);
        });
    }
}