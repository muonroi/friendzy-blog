using FriendzyBlog.Data;

namespace FriendzyBlog.Api
{
    public static class MigrationManager
    {
        public static WebApplication MigrateDatabase(this WebApplication app)
        {
            using (IServiceScope scope = app.Services.CreateScope())
            {
                using FriendzyBlogContext context = scope.ServiceProvider.GetRequiredService<FriendzyBlogContext>();
                context.Database.Migrate();
                context.SeedAsync().Wait();
            }
            return app;
        }
    }
}