using BlogEngine.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BlogEngine.Infrastructure.DataAccess;

internal class BlogEngineDBContext : DbContext
{

    public BlogEngineDBContext(DbContextOptions options) : base(options) {}

    public DbSet<Post> Posts { get; set; }

}
