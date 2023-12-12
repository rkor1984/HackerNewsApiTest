using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;
using Moq;
using Xunit;

public class HackerNewsCacheServiceTests
{
    [Fact]
    public async Task GetBestStoriesAsync_Should_Return_Cached_Stories_If_Available()
    {
        // Arrange
        var cache = new MemoryCache(new MemoryCacheOptions());
        var apiServiceMock = new Mock<IHackerNewsService>();
        var cacheService = new HackerNewsCacheService(cache, apiServiceMock.Object);

        var storyIds = new List<int> { 1, 2, 3 };
        apiServiceMock.Setup(api => api.GetBestStoryIds()).ReturnsAsync(storyIds);

        var expectedStories = new List<Story>
        {
            new Story { Id = 1, Title = "Title 1" },
            new Story { Id = 2, Title = "Title 2" },
            new Story { Id = 3, Title = "Title 3" }
        };

        apiServiceMock.Setup(api => api.GetStory(It.IsAny<int>()))
            .Returns<int>(id => Task.FromResult(expectedStories.Find(s => s.Id == id)));

        // Act
        var result = await cacheService.GetBestStoriesAsync(3);

        // Assert
        Assert.Equal(expectedStories, result);

        // Verify that GetBestStoryIds is called
        apiServiceMock.Verify(api => api.GetBestStoryIds(), Times.Once);
    }
}
