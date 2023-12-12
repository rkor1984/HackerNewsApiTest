using HackerNewsApiService.Models;
using HackerNewsApiService.Services.IServices;
using Microsoft.Extensions.Caching.Memory;

namespace HackerNewsApiService.Services
{
    public class HackerNewsCacheService : IHackerNewsCacheService
    {
        private readonly IMemoryCache _cache;
        private readonly IHackerNewsService _apiService;

        public HackerNewsCacheService(IMemoryCache cache, IHackerNewsService apiService)
        {
            _cache = cache;
            _apiService = apiService;
        }

        public async Task<IEnumerable<Story>> GetBestStoriesAsync(int n)
        {
            var bestStoryIds = await _apiService.GetBestStoryIds(); // donot cache as best stories may change frequently
            var bestNStoryIds = bestStoryIds.Take(n);

            return await GetCachedStories(bestNStoryIds);
        }

        private async Task<IEnumerable<Story>> GetCachedStories(IEnumerable<int> storyIds)
        {
            var tasks = storyIds.Select(storyId => GetCachedStory(storyId));
            return await Task.WhenAll(tasks);
        }

        private async Task<Story> GetCachedStory(int storyId) //cache as actual story may not change frequently
        {
            var cached = _cache.TryGetValue(storyId, out Story cachedStory);

            if (cached)
            {
                return cachedStory;
            }

            var story = await _apiService.GetStory(storyId);

            var cacheEntryOptions = new MemoryCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5)
            };

            _cache.Set(storyId, story, cacheEntryOptions);

            return story;
        }
    }
}