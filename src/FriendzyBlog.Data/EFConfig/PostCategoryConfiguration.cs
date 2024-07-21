namespace FriendzyBlog.Data.EFConfig
{
    public class PostCategoryConfiguration : IEntityTypeConfiguration<PostCategory>
    {
        public void Configure(EntityTypeBuilder<PostCategory> builder)
        {
            _ = builder.HasIndex(b => new { b.Slug, b.ParentId }).HasDatabaseName("IX_Slug_ParentId").IsUnique();
        }
    }
}