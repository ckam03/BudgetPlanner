using Microsoft.AspNetCore.Mvc.Testing;

namespace BudgetPlanner.Tests.IntegrationTests.Categories;

public class GetCategoriesTest : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program> _factory;

    public GetCategoriesTest(WebApplicationFactory<Program> factory)
    {
        _factory = factory;
    }

    [Fact]
    public async Task GetCategories_ReturnsSuccessStatusCode()
    {
        // Arrange
        var client = _factory.CreateClient();
        // Act
        var response = await client.GetAsync("/categories");
        // Assert
        response.EnsureSuccessStatusCode();
    }
}
