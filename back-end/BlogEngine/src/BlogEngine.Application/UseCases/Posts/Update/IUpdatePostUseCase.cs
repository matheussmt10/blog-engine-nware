using BlogEngine.Communication.Requests.Post;
using BlogEngine.Communication.responses;

namespace BlogEngine.Application.UseCases.Posts.Update;
public interface IUpdatePostUseCase
{
    public Task Execute(long id, RequestPost request);
}
