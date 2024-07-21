namespace FriendzyBlog.Api
{
    public static class MigrationManager
    {
        public static WebApplication MigrateDatabase(this WebApplication app)
        {
            using (IServiceScope scope = app.Services.CreateScope())
            {
                FriendzyBlogContext context = scope.ServiceProvider.GetRequiredService<FriendzyBlogContext>();
                context.Database.Migrate();

                new InitialHostDbBuilder(context).Create();
            }
            return app;
        }
    }
}