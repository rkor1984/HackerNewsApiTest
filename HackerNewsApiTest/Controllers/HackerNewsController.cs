using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
[ResponseCache(Duration = 300, Location = ResponseCacheLocation.Any)] // Cache for 5 minutes
public class HackerNewsController : ControllerBase
{
    private readonly IHackerNewsCacheService _hackerNewsService;

    public HackerNewsController(IHackerNewsCacheService hackerNewsService)
    {
        _hackerNewsService = hackerNewsService ?? throw new ArgumentNullException(nameof(hackerNewsService));
    }

    [HttpGet("top/{n}")]
    public async Task<ActionResult<IEnumerable<Story>>> GetBestStories(int n)
    {
        try
        {
            var stories = await _hackerNewsService.GetBestStoriesAsync(n);
            return Ok(stories.OrderByDescending(s => s.Score));
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }
}
