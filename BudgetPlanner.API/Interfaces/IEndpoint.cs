﻿namespace BudgetPlanner.API.Interfaces;

public interface IEndpoint
{
    static abstract void MapEndpoint(IEndpointRouteBuilder app);
}
