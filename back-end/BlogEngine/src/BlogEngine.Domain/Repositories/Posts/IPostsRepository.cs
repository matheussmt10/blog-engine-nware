using BlogEngine.Domain.Entities;

namespace BlogEngine.Domain.Repositories.Posts;
public interface IPostsRepository
{
    public Task Add(Post post);

    public Task<List<Post>> GetAll();
    Task<List<Post>> GetAllByCategoryId(long categoryId);

    Task<bool> CheckIfExistByTitle(string title);

    Task<Post?> GetById(long id);

    void Update(Post post);
}
