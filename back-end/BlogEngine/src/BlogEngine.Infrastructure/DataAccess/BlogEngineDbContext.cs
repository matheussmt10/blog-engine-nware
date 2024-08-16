using BlogEngine.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BlogEngine.Infrastructure.DataAccess;

public class BlogEngineNwareDBContext : DbContext
{
    public DbSet<Post> Posts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var connectionString = "Server=localhost;Database=blog_engine_db;port=5432;Uid=admin;Pwd=blog_12@#Bh%232";

        var serverVersion = new MySqlServerVersion(new Version());
        optionsBuilder.UseMySql(connectionString, serverVersion);
    }
}
