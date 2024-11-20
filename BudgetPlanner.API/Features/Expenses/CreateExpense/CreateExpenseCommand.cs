using BudgetPlanner.API.Data;
using BudgetPlanner.API.Extensions;
using BudgetPlanner.API.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BudgetPlanner.API.Features.Expenses.CreateExpense;

public sealed record CreateExpenseCommand(CreateExpenseRequest Request) : IRequest<ExpenseResponse>;

public class CreateExpenseCommandHandler(BudgetPlannerDbContext context)
    : IRequestHandler<CreateExpenseCommand, ExpenseResponse>
{
    public async Task<ExpenseResponse> Handle(CreateExpenseCommand request, CancellationToken cancellationToken)
    {
        var (name, budget, activity, available, isRecurring, occurrence, date, id) = request.Request;
        var category = await context.Categories
            .Include(x => x.Expenses)
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken) ?? throw new Exception("category not found");

        Expense expense = new()
        {
            Name = name,
            Budget = budget,
            Activity = activity,
            IsRecurring = isRecurring,
            Recurrence = isRecurring ? occurrence.ToEnum() : Recurrence.None,
            Date = new DateOnly(date.Year, date.Month, date.Day),
            Category = category,
        };

        context.Expenses.Add(expense);
        await context.SaveChangesAsync(cancellationToken);

        // todo: project into a response to avoid circular dependency
        return new ExpenseResponse(
            expense.Name,
            expense.Budget,
            expense.Activity,
            expense.Available,
            expense.Recurrence.ToString(),
            expense.Date);
    }
}
