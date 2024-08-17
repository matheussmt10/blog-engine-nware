using BlogEngine.Domain.Entities;

namespace BlogEngine.Domain.Repositories.Posts;
public interface IPostsRepository
{
    public Task Add(Post post);

    public Task<List<Post>> GetAll();
    Task<List<Post>> GetAllByCategoryId(Guid categoryId);

    Task<Post?> GetById(Guid id);

    void Update(Post post);
}
