using BudgetPlanner.API.Data;
using BudgetPlanner.API.Features.Expenses.Requests;
using BudgetPlanner.API.Models;
using BudgetPlanner.API.Shared;

namespace BudgetPlanner.API.Features.Expenses.Services;

public class ExpenseService(BudgetPlannerDbContext context)
{
    public async Task<Result<Expense>> UpdateExpenseAsync(UpdateExpenseRequest request)
    {
        var expense = await context.Expenses.FindAsync(request.Id);

        if (expense is null)
        {
            return Result<Expense>.Failure("Expense not found");
        }

        var updatedExpense = expense.Update(request);
        context.Expenses.Update(updatedExpense);
        await context.SaveChangesAsync();

        return Result<Expense>.Success(expense);
    }
}
