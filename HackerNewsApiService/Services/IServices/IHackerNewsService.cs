using HackerNewsApiService.Models;

namespace HackerNewsApiService.Services.IServices
{
    public interface IHackerNewsService
    {
        Task<IEnumerable<int>> GetBestStoryIds();
        Task<Story> GetStory(int storyId);
    }
}