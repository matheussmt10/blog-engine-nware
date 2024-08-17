using AutoMapper;
using BlogEngine.Communication.Responses.Category;
using BlogEngine.Domain.Repositories.Categories;

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

        return new ResponseCategories
        {
            Categories = _mapper.Map<List<ResponseCategory>>(result)
        };
    }
}
