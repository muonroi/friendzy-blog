namespace FriendzyBlog.Core.Domain.Content
{
    [Table("PostInSeries")]
    public class PostInSeries : MEntity
    {
        public Guid PostId { get; set; }
        public Guid SeriesId { get; set; }
        public int DisplayOrder { get; set; }
    }
}