using BlogEngine.Domain.Entities;
using BlogEngine.Domain.Repositories;
using BlogEngine.Domain.Repositories.Posts;
using BlogEngine.Exception.ExceptionBase;
using BlogEngine.Exception;

namespace BlogEngine.Application.UseCases.Posts.Delete;

public class DeletePostUseCase : IDeletePostUseCase
{
    private readonly IPostsRepository _repository;
    private readonly IUnitOfWork _unitOfWork;


    public DeletePostUseCase(
        IPostsRepository repository,
        IUnitOfWork unitOfWork
        )

        {
        _repository = repository;
        _unitOfWork = unitOfWork;
       }

    public async Task Execute(long id)
    {
        var result = await _repository.Delete(id);

        if (!result)
        {
            throw new NotFoundException(ResourceErrorMessages.POST_NOT_FOUND);
        }

        await _unitOfWork.Commit();
    }
}
