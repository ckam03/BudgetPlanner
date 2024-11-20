using BudgetPlanner.API.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BudgetPlanner.API.Features.Categories.DeleteCategories;

public class DeleteCategoryEndpoint : IEndpoint
{
    public void MapEndpoint(WebApplication app)
    {
        app.MapDelete("/category", async (IMediator mediator, [FromBody] DeleteCategoryRequest request) =>
        {
            var response = await mediator.Send(new DeleteCategoryCommand(request.Ids));
            return TypedResults.Ok(response);
        });
    }
}

public sealed record DeleteCategoryRequest(List<Guid> Ids);
