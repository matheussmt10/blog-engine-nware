using BlogEngine.Domain.Entities;
using BlogEngine.Domain.Repositories.Posts;

namespace BlogEngine.Infrastructure.DataAccess.Repositories;

internal class PostsRepository : IPostsRepository
{
    public void Add(Post post)
    {
        var dbContext = new BlogEngineNwareDBContext();

        dbContext.Posts.Add(post);

        dbContext.SaveChanges();
    }
}
