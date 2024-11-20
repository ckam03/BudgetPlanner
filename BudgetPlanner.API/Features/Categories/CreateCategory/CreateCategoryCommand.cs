using BudgetPlanner.API.Data;
using BudgetPlanner.API.Models;
using MediatR;

namespace BudgetPlanner.API.Features.Categories.CreateCategory;

public sealed record CreateCategoryCommand(string Name) : IRequest<CreateCategoryResponse>;

public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, CreateCategoryResponse>
{
    private readonly BudgetPlannerDbContext _context;

    public CreateCategoryCommandHandler(BudgetPlannerDbContext context)
    {
        _context = context;
    }

    public async Task<CreateCategoryResponse> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        var name = request.Name;
        Category category = new()
        {
            Id = Guid.NewGuid(),
            Name = name
        };

        _context.Categories.Add(category);
        await _context.SaveChangesAsync(cancellationToken);

        return new CreateCategoryResponse(category.Id, category.Name, 0, 0, 0);
    }
}
