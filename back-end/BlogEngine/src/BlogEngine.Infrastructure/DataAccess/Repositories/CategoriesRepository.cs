using BlogEngine.Domain.Entities;
using BlogEngine.Domain.Repositories.Categories;
using Microsoft.EntityFrameworkCore;

namespace BlogEngine.Infrastructure.DataAccess.Repositories;

internal class CategoriesRepository : ICategoryRepository
{
    private readonly BlogEngineDBContext _dbContext;
    public CategoriesRepository(BlogEngineDBContext dbContext)
    {
        _dbContext = dbContext; 
    }
    public async Task Add(Category category)
    {
       await _dbContext.Categories.AddAsync(category);
    }

    public async Task<List<Category>> GetAll()
    {
        var result = await _dbContext.Categories.AsNoTracking().ToListAsync();

        return result;
    }

    public async Task<Category?> GetById(long id)
    {
        var result = await _dbContext.Categories.FirstOrDefaultAsync(category => category.Id == id);

        return result;
    }

    public async Task<bool> CheckIfExistByTitle(string title)
    {
        var result = await _dbContext.Categories.AnyAsync(category => category.Title == title);

        return result;
    }

    public void Update(Category category)
    {
        _dbContext.Categories.Update(category);
    }
}
