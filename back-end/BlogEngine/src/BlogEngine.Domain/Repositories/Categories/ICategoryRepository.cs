using BlogEngine.Domain.Entities;

namespace BlogEngine.Domain.Repositories.Categories;
public interface ICategoryRepository
{
    public Task<List<Category>> GetAll();

    Task<Category?> GetById(long id);

    public Task Add(Category category);

    void Update(Category category);
}
