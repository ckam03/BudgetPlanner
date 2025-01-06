using System;

namespace BudgetPlanner.API.Models;

public class MonthlyBudgetCategory
{
    public Guid MonthlyBudgetId { get; set; }
    public MonthlyBudget MonthlyBudget { get; set; } = default!;
    public Guid CategoryId { get; set; }
    public Category Category { get; set; } = default!;
}
