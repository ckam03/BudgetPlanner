using BudgetPlanner.API.Features.Categories.Requests;
using BudgetPlanner.API.Models;
using FluentValidation;

namespace BudgetPlanner.API.Features.Categories.Validators;

public class CreateCategoryValidator : AbstractValidator<CreateCategoryRequest>
{
    public CreateCategoryValidator()
    {
        RuleFor(x => x.Name).NotEmpty().MaximumLength(25);
    }
}
