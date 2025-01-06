namespace BudgetPlanner.API.Models;

public class Target
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal Amount { get; set; }
}
