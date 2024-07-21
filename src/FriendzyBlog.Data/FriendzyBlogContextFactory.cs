namespace FriendzyBlog.Data
{
    public class FriendzyBlogContextFactory : IDesignTimeDbContextFactory<FriendzyBlogContext>
    {
        public FriendzyBlogContext CreateDbContext(string[] args)
        {
            string? environmentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{environmentName}.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables()
                .Build();

            DbContextOptionsBuilder<FriendzyBlogContext> builder = new();
            _ = builder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            return new FriendzyBlogContext(builder.Options, new NoMediator());
        }
    }
}