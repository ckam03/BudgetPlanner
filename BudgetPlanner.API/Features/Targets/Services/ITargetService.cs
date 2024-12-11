using System;

namespace BudgetPlanner.API.Features.Targets.Services;

public interface ITargetService
{
    Task CreateTargetAsync(string target);
}
