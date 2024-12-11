namespace BudgetPlanner.API.Interfaces;

public interface IEndpoint
{
    static abstract void MapEndpoint(IEndpointRouteBuilder app);
}

public interface IEndpoint<TRequest>
{
    static abstract void MapEndpoint(IEndpointRouteBuilder app);
}

public interface IEndpoint<TRequest, TResponse>
{
    static abstract void MapEndpoint(IEndpointRouteBuilder app);
}