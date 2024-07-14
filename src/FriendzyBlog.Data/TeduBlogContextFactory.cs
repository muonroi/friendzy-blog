namespace FriendzyBlog.Data
{
    public class FriendzyBlogContextFactory : IDesignTimeDbContextFactory<FriendzyBlogContext>
    {
        public FriendzyBlogContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                 .SetBasePath(Directory.GetCurrentDirectory())
                 .AddJsonFile("appsettings.json")
                 .Build();
            DbContextOptionsBuilder<FriendzyBlogContext> builder = new();
            _ = builder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            return new FriendzyBlogContext(builder.Options);
        }
    }
}