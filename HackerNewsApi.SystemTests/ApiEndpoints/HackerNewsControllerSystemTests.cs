using HackerNewsApiTest;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

public class HackerNewsControllerSystemTests : IClassFixture<WebApplicationFactory<Startup>>
{
    private readonly HttpClient _client;

    public HackerNewsControllerSystemTests(WebApplicationFactory<Startup> factory)
    {
        _client = factory.CreateClient();
    }

    [Theory]
    [InlineData(5)]
    [InlineData(10)]
    public async Task GetBestStories_Should_Return_OK(int n)
    {
        // Arrange

        // Act
        var response = await _client.GetAsync($"/HackerNews/top/{n}");

        // Assert
        response.EnsureSuccessStatusCode(); 
    }
}
