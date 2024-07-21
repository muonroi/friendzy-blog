namespace FriendzyBlog.Data.EFConfig
{
    public class SeriesConfiguration : IEntityTypeConfiguration<Series>
    {
        public void Configure(EntityTypeBuilder<Series> builder)
        {
            _ = builder.HasIndex(b => b.Slug).HasDatabaseName("IX_Slug").IsUnique();
            _ = builder.HasIndex(b => new { b.Slug, b.AuthorUserId }).HasDatabaseName("IX_Slug_AuthorUserId").IsUnique();
        }
    }
}