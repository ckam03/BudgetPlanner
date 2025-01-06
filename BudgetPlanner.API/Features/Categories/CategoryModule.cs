using BudgetPlanner.API.Features.Categories.Endpoints;
using BudgetPlanner.API.Features.Categories.Requests;
using BudgetPlanner.API.Features.Categories.Services;
using BudgetPlanner.API.Features.Categories.Validators;
using BudgetPlanner.API.Models;
using FluentValidation;

namespace BudgetPlanner.API.Features.Categories;

public static class CategoryModule
{
    public static void AddCategoryServices(this IServiceCollection services)
    {
        services.AddScoped<CategoryService>();
        services.AddScoped<IValidator<CreateCategoryRequest>, CreateCategoryValidator>();
    }

    public static void MapCategoryEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/category");

        CreateCategoryEndpoint.MapEndpoint(group);
        DeleteCategoryEndpoint.MapEndpoint(group);
        GetCategoriesEndpoint.MapEndpoint(group);
    }
}
