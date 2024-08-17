namespace BlogEngine.Domain.Repositories;
public interface IUnitOfWork
{
    Task<int> Commit();
}
