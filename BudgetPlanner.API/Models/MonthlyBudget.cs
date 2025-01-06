namespace BudgetPlanner.API.Models;

public class MonthlyBudget
{
    public Guid Id { get; set; }
    public string Month { get; set; } = string.Empty;
    public ICollection<Category> Categories { get; set; } = [];
}
