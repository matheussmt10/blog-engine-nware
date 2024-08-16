using BlogEngine.Application.UseCases.Posts;
using Microsoft.Extensions.DependencyInjection;

namespace BlogEngine.Application;

public static class DependencyInjectionExtension
{
    public static void AddApplication(this IServiceCollection services)
    {
        services.AddScoped<ICreatePostUseCase, CreatePostUseCase>();
    }
}
