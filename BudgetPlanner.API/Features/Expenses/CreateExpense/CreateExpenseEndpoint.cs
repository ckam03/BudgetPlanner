using BudgetPlanner.API.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BudgetPlanner.API.Features.Expenses.CreateExpense;

public class CreateExpenseEndpoint : IEndpoint
{
    public void MapEndpoint(WebApplication app)
    {
        app.MapPost("/expenses", async (IMediator mediator, [FromBody] CreateExpenseRequest request) =>
        {
            var response = await mediator.Send(new CreateExpenseCommand(request));
            return TypedResults.Ok(response);
        });
    }
}

public sealed record CreateExpenseRequest(string Name,
                                          decimal Budget,
                                          decimal Activity,
                                          decimal Available,
                                          bool IsRecurring,
                                          string Occurrence,
                                          DueDate Date,
                                          Guid Id);

public sealed record DueDate(int Year, int Month, int Day);