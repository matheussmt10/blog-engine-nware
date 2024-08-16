using BlogEngine.Application.AutoMapper;
using BlogEngine.Application.UseCases.Posts;
using BlogEngine.Application.UseCases.Posts.GetById;
using Microsoft.Extensions.DependencyInjection;

namespace BlogEngine.Application;

public static class DependencyInjectionExtension
{
    public static void AddApplication(this IServiceCollection services)
    {
        AddAutoMapper(services);
        AddUseCases(services);
    }

    private static void AddAutoMapper(IServiceCollection services)
    {
        services.AddAutoMapper(typeof(AutoMapping));

    }

    private static void AddUseCases(IServiceCollection services)
    {
        services.AddScoped<ICreatePostUseCase, CreatePostUseCase>();
        services.AddScoped<IGetAllPostsUseCase, GetAllPostsUseCase>();
        services.AddScoped<IGetPostByIdUseCase, GetPostByIdUseCase>();
    }
}
