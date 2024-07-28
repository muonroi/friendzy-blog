namespace FriendzyBlog.Data
{
    public class FriendzyBlogContext(DbContextOptions<FriendzyBlogContext> options, IMediator mediator) : MDbContext(options, mediator), IIdentityAuth
    {
        public DbSet<Post> Posts { get; set; }
        public DbSet<PostCategory> PostCategories { get; set; }
        public DbSet<PostTag> PostTags { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<PostActivityLog> PostActivityLogs { get; set; }
        public DbSet<Series> Series { get; set; }
        public DbSet<PostInSeries> PostInSeries { get; set; }
        public DbSet<MUserAccount> UserAccounts { get; set; }
        public DbSet<MUser> Users { get; set; }
        public DbSet<MRole> Roles { get; set; }
        public DbSet<MPermission> Permissions { get; set; }
        public DbSet<MUserRole> UserRoles { get; set; }
        public DbSet<MLanguage> Languages { get; set; }
        public DbSet<MUserLogin> UserLogins { get; set; }
        public DbSet<MUserToken> UserTokens { get; set; }
        public DbSet<MUserLoginAttempt> MUserLoginAttempts { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            _ = builder.ApplyConfiguration(new MUserConfiguration());
            _ = builder.ApplyConfiguration(new MUserAccountConfiguration());
            _ = builder.ApplyConfiguration(new MUserLoginConfiguration());
            _ = builder.ApplyConfiguration(new PostActivityLogConfiguration());
            _ = builder.ApplyConfiguration(new PostCategoryConfiguration());
            _ = builder.ApplyConfiguration(new PostConfiguration());
            _ = builder.ApplyConfiguration(new MUserRoleConfiguration());
            _ = builder.ApplyConfiguration(new SeriesConfiguration());
            _ = builder.ApplyConfiguration(new PostInSeriesConfiguration());
            _ = builder.ApplyConfiguration(new PostTagConfiguration());
        }
    }
}