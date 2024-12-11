using BudgetPlanner.API.Data;
using BudgetPlanner.API.Features.Expenses.Requests;
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

    public static async Task<Results<Ok<Expense>, NotFound<string>>> HandleAsync(BudgetPlannerDbContext context,
                                                                                 [FromBody] UpdateExpenseRequest request)
    {
        var expense = await context.Expenses.FindAsync(request.Id);

        if (expense is null)
        {
            return TypedResults.NotFound("Expense not found");
        }

        var updatedExpense = expense.Update(request);
        context.Expenses.Update(updatedExpense);
        await context.SaveChangesAsync();
        return TypedResults.Ok(expense);
    }
}
