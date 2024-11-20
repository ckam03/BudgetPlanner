using System;
using System.Linq.Expressions;
using BudgetPlanner.API.Features.Categories.GetCategories;
using BudgetPlanner.API.Features.Expenses;
using BudgetPlanner.API.Features.Expenses.GetExpenses;
using BudgetPlanner.API.Models;

namespace BudgetPlanner.API.Features.Categories;

public static class Mappings
{
    public static Expression<Func<Category, GetCategoriesResponse>> ToGetCategoriesResponse = (category) => new GetCategoriesResponse(
        category.Id,
        category.Name,
        category.Expenses.Sum(expense => expense.Budget),
        category.Expenses.Sum(expense => expense.Activity),
        category.Expenses.Sum(expense => expense.Budget - expense.Activity),
        category.Expenses.Select(expense => new GetExpensesResponse(
            expense.Id,
            expense.Name,
            expense.Budget,
            expense.Activity,
            expense.Budget - expense.Activity,
            expense.Recurrence,
            expense.Date
        )).ToList()
    );
    // {
    //     return new GetCategoriesResponse(
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
    //     );
    // }
}
