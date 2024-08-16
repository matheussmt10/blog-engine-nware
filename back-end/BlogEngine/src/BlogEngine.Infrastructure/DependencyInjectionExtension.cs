using BlogEngine.Domain.Repositories.Posts;
using BlogEngine.Infrastructure.DataAccess;
using BlogEngine.Infrastructure.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BlogEngine.Infrastructure;

public static class DependencyInjectionExtension
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        AddDbContext(services, configuration);
        AddRepositories(services);
    }

    private static void AddRepositories(IServiceCollection services)
    {
        services.AddScoped<IPostsRepository, PostsRepository>();
    }  
    
    private static void AddDbContext(IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("ConnectionDb");

        var serverVersion = new MySqlServerVersion(new Version(8, 0, 39));

        services.AddDbContext<BlogEngineDBContext>(config => config.UseMySql(connectionString, serverVersion));
    }
}
