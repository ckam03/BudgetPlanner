using BudgetPlanner.API.Data;
using BudgetPlanner.API.Features.Expenses.Requests;
using BudgetPlanner.API.Features.Expenses.Responses;
using BudgetPlanner.API.Interfaces;
using BudgetPlanner.API.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BudgetPlanner.API.Features.Expenses.Endpoints;

public sealed class CreateExpenseEndpoint : IEndpoint
{
    public static void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("/", HandleAsync).WithName("CreateExpense");
    }

    public static async Task<CreatedAtRoute<CreateExpenseResponse>> HandleAsync(
        [FromBody] CreateExpenseRequest request,
        BudgetPlannerDbContext context
    )
    {
        Category category =
            await context.Categories
                .Include(x => x.Expenses)
                .FirstOrDefaultAsync(x => x.Id == request.Id)
            ?? throw new Exception("category not found");

        var expense = request.ToExpense(category);
        context.Expenses.Add(expense);
        await context.SaveChangesAsync();

        var response = expense.ToResponse();
        return TypedResults.CreatedAtRoute(response, "CreateExpense");
    }
}
