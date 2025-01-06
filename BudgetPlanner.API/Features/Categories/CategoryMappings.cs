using BudgetPlanner.API.Features.Categories.Responses;
using BudgetPlanner.API.Features.Expenses.Responses;
using BudgetPlanner.API.Models;
using System.Linq.Expressions;

namespace BudgetPlanner.API.Features.Categories;

public static class CategoryMappings
{
    public static Expression<Func<Category, GetCategoriesResponse>> ToGetCategoriesResponse = (
        category
    ) => new GetCategoriesResponse(
            category.Id,
            category.Name,
            category.Expenses.Sum(expense => expense.Budget),
            category.Expenses.Sum(expense => expense.Activity),
            category.Expenses.Sum(expense => expense.Budget - expense.Activity),
            category.Expenses
                .Select(expense =>
                        new GetExpensesResponse(
                            expense.Id,
                            expense.Name,
                            expense.Budget,
                            expense.Activity,
                            expense.Budget - expense.Activity,
                            expense.Recurrence.ToString(),
                            expense.IsRecurring,
                            expense.Date
                        )
                )
                .ToList()
        );
}
