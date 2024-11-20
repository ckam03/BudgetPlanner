namespace BudgetPlanner.API.Models;

public class Category
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;

    public ICollection<Expense> Expenses { get; set; } = default!;
}