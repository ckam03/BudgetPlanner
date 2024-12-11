namespace BudgetPlanner.API.Features.Expenses.Responses;

public record CreateExpenseResponse(string Name,
                                    decimal Budget,
                                    decimal Activity,
                                    decimal Available,
                                    string Recurrence,
                                    bool IsRecurring,
                                    DateOnly? Date);