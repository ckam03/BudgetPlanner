using System;
using BudgetPlanner.API.Data;
using BudgetPlanner.API.Features.Budget.Services;
using BudgetPlanner.API.Features.Categories;
using BudgetPlanner.API.Features.Categories.Requests;
using BudgetPlanner.API.Features.Categories.Responses;
using BudgetPlanner.API.Models;
using Microsoft.EntityFrameworkCore;

namespace BudgetPlanner.API.Features.Categories.Services;

public class CategoryService(BudgetPlannerDbContext context)
{
    public async Task<List<GetCategoriesResponse>> GetCategoriesAsync()
    {
        return await context.Categories
            .Select(CategoryMappings.ToGetCategoriesResponse)
            .ToListAsync();
    }

    public async Task<CreateCategoryResponse> CreateCategoryAsync(
        CreateCategoryRequest request,
        MonthlyBudget budget
    )
    {
        var category = new Category
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
            MonthlyBudget = budget
        };

        context.Categories.Add(category);
        await context.SaveChangesAsync();

        return new CreateCategoryResponse(category.Id, category.Name, 0, 0, 0);
    }
}
