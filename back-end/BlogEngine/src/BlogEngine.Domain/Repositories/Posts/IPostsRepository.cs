using BlogEngine.Domain.Entities;

namespace BlogEngine.Domain.Repositories.Posts;
public interface IPostsRepository
{
    public void Add(Post post);
}
