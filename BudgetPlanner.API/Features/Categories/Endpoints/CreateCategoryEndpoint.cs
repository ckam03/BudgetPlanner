using BudgetPlanner.API.Features.Budget.Services;
using BudgetPlanner.API.Features.Categories.Requests;
using BudgetPlanner.API.Features.Categories.Responses;
using BudgetPlanner.API.Features.Categories.Services;
using BudgetPlanner.API.Interfaces;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace BudgetPlanner.API.Features.Categories.Endpoints;

public sealed class CreateCategoryEndpoint : IEndpoint
{
    public static void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("/", HandleAsync);
    }

    public static async Task<Results<Ok<CreateCategoryResponse>, ProblemHttpResult>> HandleAsync(
        [FromBody] CreateCategoryRequest request,
        BudgetService budgetService,
        CategoryService categoryService,
        IValidator<CreateCategoryRequest> validator
    )
    {
        ValidationResult result = await validator.ValidateAsync(request);

        if (!result.IsValid)
        {
            return TypedResults.Problem(
                detail: result.Errors[0].ErrorMessage,
                statusCode: StatusCodes.Status400BadRequest,
                title: "Invalid Category name"
            );
        }
        var budget = await budgetService.TryGetCurrentMonthAsync();

        if ()

        // if (budget.IsSuccess && budget.Value is not null)
        // {
        //     var category = await categoryService.CreateCategoryAsync(request, budget.Value);
        //     return TypedResults.Ok(category);
        // }

        // return TypedResults.Problem(
        //     detail: budget.Error,
        //     statusCode: StatusCodes.Status400BadRequest,
        //     title: "No budget found for the current month"
        // );
    }
}
