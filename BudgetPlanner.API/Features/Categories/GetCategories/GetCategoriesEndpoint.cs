using BudgetPlanner.API.Interfaces;
using MediatR;

namespace BudgetPlanner.API.Features.Categories.GetCategories;

public class GetCategoriesEndpoint : IEndpoint
{
    public void MapEndpoint(WebApplication app)
    {
        app.MapGet("/category", async (IMediator mediator) =>
        {
            var result = await mediator.Send(new GetCategoriesQuery());
            return TypedResults.Ok(result);
        });
    }
}

