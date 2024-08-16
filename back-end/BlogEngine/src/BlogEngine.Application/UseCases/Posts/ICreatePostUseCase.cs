using BlogEngine.Communication.requests;
using BlogEngine.Communication.responses;
using BlogEngine.Domain.Entities;

namespace BlogEngine.Application.UseCases.Posts;
public interface ICreatePostUseCase
{
    public Task<ResponsePost> Execute(RequestPost request);
}
