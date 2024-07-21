namespace FriendzyBlog.Data.EFConfig
{
    public class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            _ = builder.HasIndex(b => b.UserName).HasDatabaseName("IX_UserName").IsUnique();
        }
    }
}