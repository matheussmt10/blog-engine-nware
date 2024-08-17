using BlogEngine.Communication.Responses.Category;

namespace BlogEngine.Application.UseCases.Categories.GetById;
public interface IGetCategoryByIdUseCase
{
    public Task<ResponseCategory> Execute(Guid id);
}
