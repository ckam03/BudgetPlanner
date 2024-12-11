using BudgetPlanner.API.Data;

namespace BudgetPlanner.API.Features.Targets.Services;

public class TargetService(BudgetPlannerDbContext context) : ITargetService
{
    private readonly BudgetPlannerDbContext _context = context;


    public async Task CreateTargetAsync(string target)
    {
        //_context.Targets.Add(target);
        await _context.SaveChangesAsync();
    }
}
