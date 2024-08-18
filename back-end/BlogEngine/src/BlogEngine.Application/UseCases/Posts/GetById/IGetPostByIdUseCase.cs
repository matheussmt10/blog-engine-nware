using BlogEngine.Communication.Responses.Post;

namespace BlogEngine.Application.UseCases.Posts.GetById;
public interface IGetPostByIdUseCase
{
    public Task<ResponsePost> Execute(long id);
}
