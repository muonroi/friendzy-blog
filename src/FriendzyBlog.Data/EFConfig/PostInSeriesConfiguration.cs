namespace FriendzyBlog.Data.EFConfig
{
    public class PostInSeriesConfiguration : IEntityTypeConfiguration<PostInSeries>
    {
        public void Configure(EntityTypeBuilder<PostInSeries> builder)
        {
            _ = builder.Ignore(x => x.Id);
            _ = builder.HasKey(x => new { x.PostId, x.SeriesId });
        }
    }
}