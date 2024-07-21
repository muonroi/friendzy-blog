namespace FriendzyBlog.Data.EFConfig
{
    public class AppUserLoginConfiguration : IEntityTypeConfiguration<AppUserLogin>
    {
        public void Configure(EntityTypeBuilder<AppUserLogin> builder)
        {
            _ = builder.HasIndex(b => b.UserId).HasDatabaseName("IX_UserId").IsUnique();
        }
    }
}