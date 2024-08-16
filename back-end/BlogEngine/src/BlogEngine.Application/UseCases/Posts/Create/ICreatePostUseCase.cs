using BlogEngine.Communication.requests;
using BlogEngine.Communication.responses;
using BlogEngine.Domain.Entities;

namespace BlogEngine.Application.UseCases.Posts.Create;
public interface ICreatePostUseCase
{
    public Task<ResponseCreatedPost> Execute(RequestCreatePost request);
}
