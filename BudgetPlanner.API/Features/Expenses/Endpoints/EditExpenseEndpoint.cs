using BudgetPlanner.API.Features.Expenses.Requests;
using BudgetPlanner.API.Features.Expenses.Services;
using BudgetPlanner.API.Interfaces;
using BudgetPlanner.API.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace BudgetPlanner.API.Features.Expenses.Endpoints;

public sealed class EditExpenseEndpoint : IEndpoint
{
    public static void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPut("/", HandleAsync);
    }

    private static async Task<Results<Ok<Expense>, NotFound<string>>> HandleAsync(
        [FromBody] UpdateExpenseRequest request,
        ExpenseService expenseService
    )
    {
        var updatedExpense = await expenseService.UpdateExpenseAsync(request);

        return !updatedExpense.IsSuccess
            ? TypedResults.NotFound(updatedExpense.Error)
            : TypedResults.Ok(updatedExpense.Value);
    }
}
