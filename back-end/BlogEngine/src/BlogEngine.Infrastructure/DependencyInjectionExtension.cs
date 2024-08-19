using BlogEngine.Domain.Repositories;
using BlogEngine.Domain.Repositories.Categories;
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
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IPostsRepository, PostsRepository>();
        services.AddScoped<ICategoryRepository, CategoriesRepository>();
    }  
    
    private static void AddDbContext(IServiceCollection services, IConfiguration configuration)
    {
        var dbHost = Environment.GetEnvironmentVariable("DB_HOST");
        var dbName = Environment.GetEnvironmentVariable("DB_NAME");
        var dbUser = Environment.GetEnvironmentVariable("DB_USER");
        var dbPassword = Environment.GetEnvironmentVariable("DB_PASSWORD");

        var connectionString = $"Server={dbHost};Database={dbName};port=3306;Uid={dbUser};Pwd={dbPassword}";

        var serverVersion = new MySqlServerVersion(new Version(9, 0, 1));

        services.AddDbContext<BlogEngineDBContext>(config => config.UseMySql(connectionString, serverVersion));
    }
}
