using BlogEngine.Domain.Entities;

namespace BlogEngine.Application.UseCases.Posts.Delete;
public interface IDeletePostUseCase
{
    Task Execute(long id);
}
