using BlogEngine.Domain.Repositories.Posts;
using BlogEngine.Infrastructure.DataAccess.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace BlogEngine.Infrastructure;

public static class DependencyInjectionExtension
{
    public static void AddInfrastructure(this IServiceCollection services)
    {
        services.AddScoped<IPostsRepository, PostsRepository>();
    }
}
