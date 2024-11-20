using BudgetPlanner.API.Interfaces;
using MediatR;

namespace BudgetPlanner.API.Features.Expenses.GetExpenses;

public class GetExpensesEndpoint : IEndpoint
{
    public void MapEndpoint(WebApplication app)
    {
        app.MapGet("/expenses", async (IMediator mediator) =>
        {
            List<GetExpensesResponse> expenses = await mediator.Send(new GetExpensesQuery());
            return TypedResults.Ok(expenses);
        });
    }
}
