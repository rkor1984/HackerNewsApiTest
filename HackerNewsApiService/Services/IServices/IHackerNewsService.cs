public interface IHackerNewsService
{
    Task<IEnumerable<int>> GetBestStoryIds();
    Task<Story> GetStory(int storyId);
}
