using BlogEngine.Communication.Requests.Post;
using BlogEngine.Communication.responses;

namespace BlogEngine.Application.UseCases.Posts.Update;
public interface IUpdatePostUseCase
{
    public Task Execute(Guid id, RequestCreatePost request);
}
