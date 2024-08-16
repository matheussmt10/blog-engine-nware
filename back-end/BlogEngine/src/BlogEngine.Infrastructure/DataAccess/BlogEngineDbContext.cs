using BlogEngine.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BlogEngine.Infrastructure.DataAccess;

internal class BlogEngineNwareDBContext : DbContext
{
    public DbSet<Post> Posts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var connectionString = "Server=localhost;Database=blog_engine_db;port=3306;Uid=root;Pwd=admin";

        var serverVersion = new MySqlServerVersion(new Version(8,0,39));
        optionsBuilder.UseMySql(connectionString, serverVersion);
    }
}
