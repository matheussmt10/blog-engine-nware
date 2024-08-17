using BlogEngine.Application.AutoMapper;
using BlogEngine.Application.UseCases.Categories.Create;
using BlogEngine.Application.UseCases.Categories.GetAll;
using BlogEngine.Application.UseCases.Categories.GetById;
using BlogEngine.Application.UseCases.Categories.Update;
using BlogEngine.Application.UseCases.Posts.Create;
using BlogEngine.Application.UseCases.Posts.GetAll;
using BlogEngine.Application.UseCases.Posts.GetById;
using BlogEngine.Application.UseCases.Posts.Update;
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
        services.AddScoped<IUpdatePostUseCase, UpdatePostUseCase>();

        services.AddScoped<ICreateCategoryUseCase, CreateCategoryUseCase>();
        services.AddScoped<IGetAllCategoriesUseCase, GetAllCategoriesUseCase>();
        services.AddScoped<IGetCategoryByIdUseCase, GetCategoryByIdUseCase>();
        services.AddScoped<IUpdateCategoryUseCase, UpdateCategoryUseCase>();

    }
}
