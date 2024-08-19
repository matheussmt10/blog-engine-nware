namespace BlogEngine.Application.UseCases.Categories.Delete;
public interface IDeleteCategoryUseCase
{
    Task Execute(long id);
}
