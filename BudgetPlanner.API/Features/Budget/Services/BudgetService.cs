using BudgetPlanner.API.Data;
using BudgetPlanner.API.Features.Budget.Requests;
using BudgetPlanner.API.Models;
using BudgetPlanner.API.Shared;
using Microsoft.EntityFrameworkCore;

namespace BudgetPlanner.API.Features.Budget.Services;

public class BudgetService(BudgetPlannerDbContext context)
{
    public async Task<Result<MonthlyBudget>> TryGetCurrentMonthAsync()
    {
        var currentMonth = DateOnly.FromDateTime(DateTime.Now);
        MonthlyBudget? budget = await context.Budgets.FirstOrDefaultAsync(
            budget => budget.Month == currentMonth.ToString("MM-yyyy")
        );

        if (budget is not null)
        {
            return Result<MonthlyBudget>.Success(budget);
        }

        return Result<MonthlyBudget>.Failure("No budget found for the current month");
    }

    public async Task<Result<MonthlyBudget>> CreateBudgetAsync()
    {
        var date = DateOnly.FromDateTime(DateTime.Now);
        var formattedDate = date.ToString("MM-yyyy");

        var newBudget = new MonthlyBudget { Id = Guid.CreateVersion7(), Month = formattedDate };
        context.Budgets.Add(newBudget);
        await context.SaveChangesAsync();
        return Result<MonthlyBudget>.Success(newBudget);
    }

    public async Task<Result<MonthlyBudget>> GetOrCreateBudgetAsync()
    {
        var date = DateOnly.FromDateTime(DateTime.Now);
        var formattedDate = date.ToString("MM-yyyy");

        var budget = await context.Budgets.FirstOrDefaultAsync(
            budget => budget.Month == formattedDate
        );

        if (budget is null)
        {
            var monthlyBudget = new MonthlyBudget { Id = Guid.NewGuid(), Month = formattedDate };

            context.Budgets.Add(monthlyBudget);
            await context.SaveChangesAsync();
            return Result<MonthlyBudget>.Success(monthlyBudget);
        }

        return Result<MonthlyBudget>.Success(budget);
    }
}
