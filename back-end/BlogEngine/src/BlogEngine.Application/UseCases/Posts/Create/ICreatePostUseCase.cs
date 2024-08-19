using BlogEngine.Communication.Requests.Post;
using BlogEngine.Communication.Responses.Post;
using BlogEngine.Domain.Entities;

namespace BlogEngine.Application.UseCases.Posts.Create;
public interface ICreatePostUseCase
{
    public Task<ResponsePost> Execute(RequestPost request);
}
