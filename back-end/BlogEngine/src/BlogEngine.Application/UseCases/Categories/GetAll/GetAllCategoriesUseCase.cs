using AutoMapper;
using BlogEngine.Communication.Responses.Category;
using BlogEngine.Domain.Repositories.Categories;
using BlogEngine.Exception.ExceptionBase;

namespace BlogEngine.Application.UseCases.Categories.GetAll;

public class GetAllCategoriesUseCase : IGetAllCategoriesUseCase
{
    private readonly ICategoryRepository _repository;
    private readonly IMapper _mapper;

    public GetAllCategoriesUseCase(ICategoryRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    public async Task<ResponseCategories> Execute()
    {
        var result = await _repository.GetAll();

        if (result.Count == 0)
        {
            throw new NoContentException(string.Empty);
        }

        return new ResponseCategories
        {
            Categories = _mapper.Map<List<ResponseCategory>>(result)
        };
    }
}
