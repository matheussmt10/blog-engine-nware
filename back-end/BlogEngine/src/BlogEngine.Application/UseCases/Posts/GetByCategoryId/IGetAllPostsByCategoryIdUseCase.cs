using BlogEngine.Communication.Responses.Post;

namespace BlogEngine.Application.UseCases.Posts.GetByCategoryId;
public interface IGetAllPostsByCategoryIdUseCase
{
    public Task<ResponsePosts> Execute(long id);
}
