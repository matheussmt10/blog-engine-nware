using BlogEngine.Communication.responses;

namespace BlogEngine.Application.UseCases.Posts.GetById;
public interface IGetPostByIdUseCase
{
    public Task<ResponseCreatedPost> Execute(Guid id);
}
