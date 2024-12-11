using System;
using BudgetPlanner.API.Data;
using BudgetPlanner.API.Features.Categories;
using BudgetPlanner.API.Features.Categories.Responses;
using Microsoft.EntityFrameworkCore;

namespace BudgetPlanner.API.Features.Services;

public class CategoryService(BudgetPlannerDbContext context)
{

    public async Task<List<GetCategoriesResponse>> GetCategoriesAsync()
    {
        return await context.Categories
            .Select(CategoryMappings.ToGetCategoriesResponse)
            .ToListAsync();
    }
}
