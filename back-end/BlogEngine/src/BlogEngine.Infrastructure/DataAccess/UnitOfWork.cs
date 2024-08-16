using BlogEngine.Domain.Repositories;

namespace BlogEngine.Infrastructure.DataAccess;
internal class UnitOfWork : IUnitOfWork
    {
        private readonly BlogEngineDBContext _dbContext;

        public UnitOfWork(BlogEngineDBContext dbContext) 
        {
            _dbContext = dbContext;
        }
    public async Task Commit() => await _dbContext.SaveChangesAsync();
    }

