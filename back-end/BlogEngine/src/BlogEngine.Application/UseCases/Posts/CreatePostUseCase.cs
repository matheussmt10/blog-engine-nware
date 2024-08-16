using BlogEngine.Communication.requests;
using BlogEngine.Communication.responses;
using BlogEngine.Domain.Entities;
using BlogEngine.Domain.Repositories;
using BlogEngine.Domain.Repositories.Posts;

namespace BlogEngine.Application.UseCases.Posts;

public class CreatePostUseCase : ICreatePostUseCase
{
    private readonly IPostsRepository _repository;
    private readonly IUnitOfWork _unitOfWork;

    public CreatePostUseCase(IPostsRepository repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }
    public async Task<ResponsePost> Execute(RequestPost request)
    {

        var post = new Post
        {
            Id = Guid.NewGuid(),
            Title = request.Title,
            PublicationDate = request.PublicationDate,
            Content = request.Content,
        };

       await _repository.Add(post);

       await _unitOfWork.Commit();

        return new ResponsePost();
    }
}
