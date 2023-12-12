public interface IHackerNewsCacheService
{
    Task<IEnumerable<Story>> GetBestStoriesAsync(int n);
}
