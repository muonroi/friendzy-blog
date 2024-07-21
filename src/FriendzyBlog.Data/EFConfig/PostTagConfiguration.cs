namespace FriendzyBlog.Data.EFConfig
{
    public class PostTagConfiguration : IEntityTypeConfiguration<PostTag>
    {
        public void Configure(EntityTypeBuilder<PostTag> builder)
        {
            _ = builder.Ignore(x => x.Id);
            _ = builder.HasKey(x => new { x.PostId, x.TagId });
        }
    }
}