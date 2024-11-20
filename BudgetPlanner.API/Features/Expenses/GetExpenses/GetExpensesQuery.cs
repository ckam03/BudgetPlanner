using BudgetPlanner.API.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BudgetPlanner.API.Features.Expenses.GetExpenses;

public record GetExpensesQuery() : IRequest<List<GetExpensesResponse>>;

public class GetExpensesQueryHandler : IRequestHandler<GetExpensesQuery, List<GetExpensesResponse>>
{
    private readonly BudgetPlannerDbContext _context;

    public GetExpensesQueryHandler(BudgetPlannerDbContext context)
    {
        _context = context;
    }
    public async Task<List<GetExpensesResponse>> Handle(GetExpensesQuery request, CancellationToken cancellationToken)
    {
        return await _context.Expenses
            .Select(expense => expense.ToGetExpensesResponse())
            .ToListAsync();
    }
}
