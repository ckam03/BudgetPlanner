namespace BudgetPlanner.API.Features.Expenses.Requests;

public sealed record UpdateExpenseRequest(
    string Name,
    decimal Budget,
    decimal Activity,
    decimal Available,
    bool IsRecurring,
    string Occurrence,
    DueDate Date,
    Guid Id
);
