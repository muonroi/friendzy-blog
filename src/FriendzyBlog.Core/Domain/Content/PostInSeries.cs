namespace FriendzyBlog.Core.Domain.Content
{
    [Table("PostInSeries")]
    public class PostInSeries : EntityBase
    {
        public Guid PostId { get; set; }
        public Guid SeriesId { get; set; }
        public int DisplayOrder { get; set; }
    }
}