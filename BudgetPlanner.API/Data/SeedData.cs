using BudgetPlanner.API.Models;

namespace BudgetPlanner.API.Data;

public static class SeedData
{
    public static List<Category> Categories = [
        new Category()
        {
            Id = new Guid("1F5D1C57-9DA8-46E0-994C-7DE8C72D2566"),
            Name = "Bills"
        },
        new Category()
        {
            Id = new Guid("5016069C-CDE7-4796-B583-7F28F6B64990"),
            Name = "Expenses"
        }
    ];

    public static List<Expense> Expenses = [
        new Expense()
        {
            Id = Guid.NewGuid(),
            Name = "Rent",
            Budget = 1000,
            Activity = 300,
            Date = new DateOnly(2022, 1, 1),
            Category = Categories.First(x => x.Name == "Bills"),
        },
        new Expense()
        {
            Id = Guid.NewGuid(),
            Name = "Groceries",
            Budget = 1000,
            Activity = 100,
            Date = new DateOnly(2022, 4, 11),
            Category = Categories.First(x => x.Name == "Expenses"),
        },

    ];
}
