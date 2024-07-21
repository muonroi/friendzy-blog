namespace FriendzyBlog.Data
{
    public class FriendzyBlogContext(DbContextOptions<FriendzyBlogContext> options, IMediator mediator) : BaseDbContext(options, mediator), IIdentityAuth
    {
        public DbSet<Post> Posts { get; set; }
        public DbSet<PostCategory> PostCategories { get; set; }
        public DbSet<PostTag> PostTags { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<PostActivityLog> PostActivityLogs { get; set; }
        public DbSet<Series> Series { get; set; }
        public DbSet<PostInSeries> PostInSeries { get; set; }
        public DbSet<AppUserAccount> UserAccounts { get; set; }
        public DbSet<AppUser> Users { get; set; }
        public DbSet<AppRole> Roles { get; set; }
        public DbSet<AppPermission> Permissions { get; set; }
        public DbSet<AppUserRole> UserRoles { get; set; }
        public DbSet<AppLanguage> Languages { get; set; }
        public DbSet<AppUserLogin> UserLogins { get; set; }
        public DbSet<AppUserToken> UserTokens { get; set; }
        public DbSet<AppUserLoginAttempt> AppUserLoginAttempts { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            _ = builder.ApplyConfiguration(new AppUserConfiguration());
            _ = builder.ApplyConfiguration(new AppUserAccountConfiguration());
            _ = builder.ApplyConfiguration(new AppUserLoginConfiguration());
            _ = builder.ApplyConfiguration(new PostActivityLogConfiguration());
            _ = builder.ApplyConfiguration(new PostCategoryConfiguration());
            _ = builder.ApplyConfiguration(new PostConfiguration());
            _ = builder.ApplyConfiguration(new AppUserRoleConfiguration());
            _ = builder.ApplyConfiguration(new SeriesConfiguration());
            _ = builder.ApplyConfiguration(new PostInSeriesConfiguration());
            _ = builder.ApplyConfiguration(new PostTagConfiguration());
        }
    }
}