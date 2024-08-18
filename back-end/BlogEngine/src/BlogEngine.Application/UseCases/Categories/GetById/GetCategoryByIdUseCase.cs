using AutoMapper;
using BlogEngine.Communication.Responses.Category;
using BlogEngine.Domain.Repositories.Categories;
using BlogEngine.Exception;
using BlogEngine.Exception.ExceptionBase;

namespace BlogEngine.Application.UseCases.Categories.GetById;

public class GetCategoryByIdUseCase : IGetCategoryByIdUseCase
{
    private readonly ICategoryRepository _repository;
    private readonly IMapper _mapper;

    public GetCategoryByIdUseCase(ICategoryRepository repository, IMapper mapper)
    {
        _repository = repository; 
        _mapper = mapper;
    }
    public async Task<ResponseCategory> Execute(long id)
    {
        var category = await _repository.GetById(id);

        if (category is null)
        {
            throw new NotFoundException(ResourceErrorMessages.CATEGORY_NOT_FOUND);
        }

        return _mapper.Map<ResponseCategory>(category);
    }
}
