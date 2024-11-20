namespace BudgetPlanner.API.Models;

public class Bill
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal Budget { get; set; }
    public decimal Activity { get; set; } = 0.0m;
    public decimal Available => Budget - Activity;
    public bool IsRecurring { get; set; }
    public Recurrence Recurrence { get; set; }
    public DateOnly Date { get; set; }
    public Category Category { get; set; } = default!;
}