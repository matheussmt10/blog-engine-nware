using AutoMapper;
using BlogEngine.Communication.Requests.Post;
using BlogEngine.Communication.Responses.Post;
using BlogEngine.Domain.Entities;
namespace BlogEngine.Application.AutoMapper;

public class AutoMapping : Profile
{
    public AutoMapping()
    {
        RequestToEntity();
        EntityToResponse();
    }

    private void RequestToEntity()
    {
        CreateMap<RequestCreatePost, Post>();
    }

    private void EntityToResponse()
    {
        CreateMap<Post, ResponseCreatedPost>();
    }

}
