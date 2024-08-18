using BlogEngine.Communication.Requests.Category;

namespace BlogEngine.Application.UseCases.Categories.Update;
public interface IUpdateCategoryUseCase
{
    public Task Execute(long id, RequestCategory request);
}
