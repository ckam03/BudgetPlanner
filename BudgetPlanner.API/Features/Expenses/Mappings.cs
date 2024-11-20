using BudgetPlanner.API.Features.Expenses.GetExpenses;
using BudgetPlanner.API.Models;
using Microsoft.EntityFrameworkCore;

namespace BudgetPlanner.API.Features.Expenses;

public static class Mappings
{
    public static GetExpensesResponse ToGetExpensesResponse(this Expense expense)
    {
        return new GetExpensesResponse(
            expense.Id,
            expense.Name,
            expense.Budget,
            expense.Activity,
            expense.Budget - expense.Activity,
            expense.Recurrence,
            expense.Date
        );
    }
}
