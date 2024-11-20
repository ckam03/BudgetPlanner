using System;
using BudgetPlanner.API.Models;

namespace BudgetPlanner.API.Extensions;

public static class ExpenseExtensions
{
    public static Recurrence ToEnum(this string occurrence)
    {
        if (Enum.TryParse<Recurrence>(occurrence, true, out var result))
        {
            return result;
        }

        return Recurrence.None;
    }
}
