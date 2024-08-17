using AutoMapper;
using BlogEngine.Communication.Requests.Category;
using BlogEngine.Communication.Responses.Category;
using BlogEngine.Domain.Entities;
using BlogEngine.Domain.Repositories;
using BlogEngine.Domain.Repositories.Categories;
using BlogEngine.Exception;
using BlogEngine.Exception.ExceptionBase;

namespace BlogEngine.Application.UseCases.Categories.Update;

public class UpdateCategoryUseCase : IUpdateCategoryUseCase
{
    private readonly ICategoryRepository _repository;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateCategoryUseCase(ICategoryRepository repository, IMapper mapper, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task Execute(Guid id, RequestCategory request)
    {
        var category = await _repository.GetById(id);

        if (category is null) 
        {
            throw new NotFoundException(ResourceErrorMessages.CATEGORY_NOT_FOUND);
        }

        Validate(request);

        _mapper.Map(request, category);

        _repository.Update(category);

        await _unitOfWork.Commit();
    }

    private void Validate(RequestCategory request)
    {
        var validator = new CategoryValidator();

        var result = validator.Validate(request);

        if (!result.IsValid)
        {
            var errorMessages = result.Errors.Select(f => f.ErrorMessage).ToList();

            throw new ErrorOnValidationException(errorMessages);
        }
    }
}
