namespace FriendzyBlog.Data.EFConfig
{
    public class PostActivityLogConfiguration : IEntityTypeConfiguration<PostActivityLog>
    {
        public void Configure(EntityTypeBuilder<PostActivityLog> builder)
        {
            _ = builder.HasIndex(b => new { b.PostId, b.UserId }).HasDatabaseName("IX_PostId_UserId").IsUnique(false);
        }
    }
}