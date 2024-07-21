namespace FriendzyBlog.Core.Domain.Content
{
    [Table("PostTags")]
    public class PostTag : EntityBase
    {
        public Guid PostId { set; get; }
        public Guid TagId { set; get; }
    }
}