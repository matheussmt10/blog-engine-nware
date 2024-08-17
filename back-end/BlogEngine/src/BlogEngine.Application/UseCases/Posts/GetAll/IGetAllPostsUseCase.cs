using BlogEngine.Communication.Responses.Post;

namespace BlogEngine.Application.UseCases.Posts.GetAll;
public interface IGetAllPostsUseCase
{
    public Task<ResponseCreatedPosts> Execute();
}
