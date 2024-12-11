using BudgetPlanner.API.Extensions;
using BudgetPlanner.API.Features.Categories.Endpoints;

namespace BudgetPlanner.API.Features.Categories;

public static class CategoryEndpoints
{
    public static void MapCategoryEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/category");

        group.MapEndpoint<CreateCategoryEndpoint>();
        group.MapEndpoint<DeleteCategoryEndpoint>();
        group.MapEndpoint<GetCategoriesEndpoint>();
    }
}
