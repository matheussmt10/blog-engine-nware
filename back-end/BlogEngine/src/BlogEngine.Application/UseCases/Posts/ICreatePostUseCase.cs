using BlogEngine.Communication.requests;
using BlogEngine.Domain.Entities;

namespace BlogEngine.Application.UseCases.Posts;
public interface ICreatePostUseCase
{
    public Post Execute(RequestPost request);
}
