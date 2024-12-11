using BudgetPlanner.API.Features.Expenses.Requests;
using BudgetPlanner.API.Features.Expenses.Responses;
using BudgetPlanner.API.Models;

namespace BudgetPlanner.API.Features.Expenses;

public static class ExpenseMappings
{
    public static Expense ToExpense(this CreateExpenseRequest request, Category category)
    {
        return new Expense
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
            Budget = request.Budget,
            Activity = request.Activity,
            Recurrence = request.Occurrence.ToEnum(),
            IsRecurring = request.IsRecurring,
            Date = new DateOnly(request.Date.Year, request.Date.Month, request.Date.Day),
            Category = category
        };
    }

    public static CreateExpenseResponse ToResponse(this Expense expense)
    {
        return new CreateExpenseResponse(
            expense.Name,
            expense.Budget,
            expense.Activity,
            expense.Budget - expense.Activity,
            expense.Recurrence.ToString(),
            expense.IsRecurring,
            expense.Date
        );
    }

    public static GetExpensesResponse ToGetExpensesResponse(this Expense expense)
    {
        return new GetExpensesResponse(
            expense.Id,
            expense.Name,
            expense.Budget,
            expense.Activity,
            expense.Budget - expense.Activity,
            expense.Recurrence.ToString(),
            expense.IsRecurring,
            expense.Date
        );
    }

    public static Recurrence ToEnum(this string occurrence)
    {
        if (Enum.TryParse<Recurrence>(occurrence, true, out var result))
        {
            return result;
        }

        return Recurrence.None;
    }

    public static Expense Update(this Expense expense, UpdateExpenseRequest request)
    {
        expense.Name = request.Name;
        expense.Budget = request.Budget;
        expense.Activity = request.Activity;
        expense.Recurrence = request.Occurrence.ToEnum();
        expense.Date = new DateOnly(request.Date.Year, request.Date.Month, request.Date.Day);

        return expense;
    }
}
