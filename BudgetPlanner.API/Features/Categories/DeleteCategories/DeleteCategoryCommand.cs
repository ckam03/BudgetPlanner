using BudgetPlanner.API.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BudgetPlanner.API.Features.Categories.DeleteCategories;

public sealed record DeleteCategoryCommand(List<Guid> Ids) : IRequest<DeleteCategoryResponse>;

public class DeleteCategoryCommandHandler(BudgetPlannerDbContext context)
    : IRequestHandler<DeleteCategoryCommand, DeleteCategoryResponse>
{
    public async Task<DeleteCategoryResponse> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
    {
        var items = await context.Categories
            .Where(x => request.Ids.Contains(x.Id))
            .ExecuteDeleteAsync(cancellationToken);

        await context.SaveChangesAsync(cancellationToken);
        return new DeleteCategoryResponse(request.Ids);
    }
}
public sealed record DeleteCategoryResponse(List<Guid> Ids);