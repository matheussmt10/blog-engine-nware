using BlogEngine.Domain.Entities;

namespace BlogEngine.Domain.Repositories.Posts;
public interface IPostsRepository
{
    public Task Add(Post post);
}
