using BlogEngine.Domain.Repositories.Posts;
using BlogEngine.Infrastructure.DataAccess;
using BlogEngine.Infrastructure.DataAccess.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace BlogEngine.Infrastructure;

public static class DependencyInjectionExtension
{
    public static void AddInfrastructure(this IServiceCollection services)
    {
        AddDbContext(services);
        AddRepositories(services);
    }

    private static void AddRepositories(IServiceCollection services)
    {
        services.AddScoped<IPostsRepository, PostsRepository>();
    }  
    
    private static void AddDbContext(IServiceCollection services)
    {
        services.AddDbContext<BlogEngineDBContext>();
    }
}
