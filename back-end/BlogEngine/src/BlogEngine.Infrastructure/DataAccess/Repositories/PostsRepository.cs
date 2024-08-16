using BlogEngine.Domain.Entities;
using BlogEngine.Domain.Repositories.Posts;

namespace BlogEngine.Infrastructure.DataAccess.Repositories;

internal class PostsRepository : IPostsRepository
{
    private readonly BlogEngineDBContext _dbContext;

    public PostsRepository(BlogEngineDBContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void Add(Post post)
    {
        

       _dbContext.Posts.Add(post);

       _dbContext.SaveChanges();
    }
}
