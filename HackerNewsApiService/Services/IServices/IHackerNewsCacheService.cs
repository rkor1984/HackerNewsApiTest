using HackerNewsApiService.Models;

namespace HackerNewsApiService.Services.IServices
{
    public interface IHackerNewsCacheService
    {
        Task<IEnumerable<Story>> GetBestStoriesAsync(int n);
    }
}