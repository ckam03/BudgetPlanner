using BudgetPlanner.API.Data;
using BudgetPlanner.API.Features.Expenses;
using BudgetPlanner.API.Features.Expenses.GetExpenses;
using BudgetPlanner.API.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BudgetPlanner.API.Features.Categories.GetCategories;

public sealed record GetCategoriesQuery() : IRequest<List<GetCategoriesResponse>>;

public class GetCategoriesQueryHandler(BudgetPlannerDbContext context)
    : IRequestHandler<GetCategoriesQuery, List<GetCategoriesResponse>>
{
    public async Task<List<GetCategoriesResponse>> Handle(GetCategoriesQuery request, CancellationToken cancellationToken)
    {
        return await context.Categories
            .Select(Mappings.ToGetCategoriesResponse)
            .ToListAsync(cancellationToken);
        // var categories = await context.Categories
        //     .Select(category => new GetCategoriesResponse(
        //         category.Id,
        //         category.Name,
        //         category.Expenses.Sum(expense => expense.Budget),
        //         category.Expenses.Sum(expense => expense.Activity),
        //         category.Expenses.Sum(expense => expense.Budget - expense.Activity),
        //         category.Expenses.Select(expense => new GetExpensesResponse(
        //             expense.Id,
        //             expense.Name,
        //             expense.Budget,
        //             expense.Activity,
        //             expense.Budget - expense.Activity,
        //             expense.Recurrence,
        //             expense.Date
        //         )).ToList()
        //     )).ToListAsync();

    }
}