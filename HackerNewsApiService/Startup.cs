
using HackerNewsApiService.Services;
using HackerNewsApiService.Services.IServices;
using Microsoft.Extensions.DependencyInjection;
namespace HackerNewsApiService;
public static class Startup
{
    public static void AddServices(this IServiceCollection services)
    {
        services.AddSingleton<IHackerNewsService, HackerNewsService>();
        services.AddSingleton<IHackerNewsCacheService, HackerNewsCacheService>();
    }
}
