namespace FriendzyBlog.Data.EFConfig
{
    public class PostConfiguration : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            _ = builder.HasIndex(b => b.Slug).HasDatabaseName("IX_Slug").IsUnique();
        }
    }
}