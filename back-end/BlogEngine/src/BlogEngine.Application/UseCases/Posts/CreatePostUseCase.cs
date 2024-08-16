using BlogEngine.Communication.requests;
using BlogEngine.Communication.responses;
using BlogEngine.Domain.Entities;
using BlogEngine.Domain.Repositories.Posts;

namespace BlogEngine.Application.UseCases.Posts;

public class CreatePostUseCase : ICreatePostUseCase
{
    private readonly IPostsRepository _repository;

    public CreatePostUseCase(IPostsRepository repository)
    {
        _repository = repository;
    }
    public Post Execute(RequestPost request)
    {

        var post = new Post
        {
            Id = Guid.NewGuid(),
            Title = request.Title,
            PublicationDate = request.PublicationDate,
            Content = request.Content,
        };

        _repository.Add(post);

        

        return post;
    }
}
