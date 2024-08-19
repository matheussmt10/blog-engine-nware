using BlogEngine.Domain.Entities;
using BlogEngine.Domain.Repositories.Posts;
using Microsoft.EntityFrameworkCore;

namespace BlogEngine.Infrastructure.DataAccess.Repositories;

internal class PostsRepository : IPostsRepository
{
    private readonly BlogEngineDBContext _dbContext;

    public PostsRepository(BlogEngineDBContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Add(Post post)
    {
      await _dbContext.Posts.AddAsync(post);
    }

    public async Task<List<Post>> GetAll()
    {
        var result = await _dbContext.Posts.AsNoTracking().OrderByDescending(post => post.PublicationDate).ToListAsync();

        return result;
    }

    public async Task<List<Post>> GetAllByCategoryId(long categoryId)
    {
        var result = await _dbContext.Posts.Where(post => post.CategoryId == categoryId).ToListAsync();

        return result;
    }

    public async Task<bool> CheckIfExistByTitle(string title)
    {
        var result = await _dbContext.Posts.AnyAsync(post => post.Title == title);

        return result;
    }

    public async Task<Post?> GetById(long id)
    {
        var result = await _dbContext.Posts.FirstOrDefaultAsync(post => post.Id == id);

        return result;
    }

    public void Update(Post post)
    {
        _dbContext.Posts.Update(post);
    }

    public async Task<bool> Delete(long id)
    {
        var result = await _dbContext.Posts.FirstOrDefaultAsync(post => post.Id == id);

        if (result is null)
        {
            return false;
        }
        _dbContext.Posts.Remove(result);

        return true;
    }
}
