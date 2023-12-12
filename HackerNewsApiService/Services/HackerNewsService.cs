
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

public class HackerNewsService : IHackerNewsService
{
    private readonly HttpClient _hackerNewsClient;
    private readonly HackerNewsApi _apiSettings;

    public HackerNewsService(IHttpClientFactory httpClientFactory,
        IOptions<AppSettings> appSettings)
    {
        _apiSettings = appSettings.Value.HackerNewsApi;
        _hackerNewsClient = httpClientFactory.CreateClient(_apiSettings.ClientName);
        _hackerNewsClient.BaseAddress = new Uri(_apiSettings.BaseUri);
    }

    public async Task<IEnumerable<int>> GetBestStoryIds()
    {
        var response = await _hackerNewsClient.GetStringAsync(_apiSettings.BestStoriesUrl);
        return JsonConvert.DeserializeObject<IEnumerable<int>>(response);
    }

    public async Task<Story> GetStory(int storyId)
    {
        var response = await _hackerNewsClient.GetStringAsync(string.Format(_apiSettings.StoryUrlFormat, storyId));
        return JsonConvert.DeserializeObject<Story>(response);
    }
}
