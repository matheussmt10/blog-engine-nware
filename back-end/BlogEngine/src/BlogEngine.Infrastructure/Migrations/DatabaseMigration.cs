using BlogEngine.Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BlogEngine.Infrastructure.Migrations;

public static class DatabaseMigration
{
    public static async Task MigrateDatabase(IServiceProvider service)
    {
        var dbContext = service.GetRequiredService<BlogEngineDBContext>();
        var test = await dbContext.Database.CanConnectAsync();
        await dbContext.Database.MigrateAsync();
    }
}
