using BlogEngine.Domain.Repositories;
using BlogEngine.Domain.Repositories.Categories;
using BlogEngine.Exception;
using BlogEngine.Exception.ExceptionBase;

namespace BlogEngine.Application.UseCases.Categories.Delete;

public class DeleteCategoryUseCase : IDeleteCategoryUseCase
{
    private readonly ICategoryRepository _repository;
    private readonly IUnitOfWork _unitOfWork;


    public DeleteCategoryUseCase(
        ICategoryRepository repository,
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
            throw new NotFoundException(ResourceErrorMessages.CATEGORY_NOT_FOUND);
        }

        await _unitOfWork.Commit();
    }
}
