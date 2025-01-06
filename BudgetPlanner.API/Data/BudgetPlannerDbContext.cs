using BudgetPlanner.API.Models;
using Microsoft.EntityFrameworkCore;

namespace BudgetPlanner.API.Data;

public class BudgetPlannerDbContext(DbContextOptions<BudgetPlannerDbContext> options)
    : DbContext(options)
{
    public DbSet<Expense> Expenses => Set<Expense>();
    public DbSet<Category> Categories => Set<Category>();
    public DbSet<MonthlyBudget> Budgets => Set<MonthlyBudget>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Expense>().Property(e => e.Budget).HasColumnType("decimal(18,2)");
        modelBuilder.Entity<Expense>().Property(e => e.Activity).HasColumnType("decimal(18,2)");
        modelBuilder.Entity<Expense>().Property(e => e.Available).HasColumnType("decimal(18,2)");

        modelBuilder.Entity<Expense>().Ignore(e => e.Available);

        modelBuilder.Entity<Category>().HasMany(c => c.Expenses).WithOne(e => e.Category);
        modelBuilder
            .Entity<MonthlyBudget>()
            .HasMany(b => b.Categories)
            .WithOne(c => c.MonthlyBudget);

        // modelBuilder
        //     .Entity<MonthlyBudget>()
        //     .HasData(
        //         new MonthlyBudget { Id = Guid.NewGuid(), Month = DateOnly.FromDateTime(DateTime.Now), Categories = [] }
        //     );

        //modelBuilder.Entity<Category>().HasData(SeedData.Categories);
        //modelBuilder.Entity<MonthlyBudget>().HasData(SeedData.MonthlyBudget);
    }
}
