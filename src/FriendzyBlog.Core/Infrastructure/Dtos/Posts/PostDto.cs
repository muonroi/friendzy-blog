namespace FriendzyBlog.Core.Infrastructure.Dtos.Posts
{
    public class PostDto : PostInListDto
    {
        public Guid CategoryId { get; set; }

        public string? Content { get; set; }

        public Guid AuthorUserId { get; set; }

        public string? Source { get; set; }

        public string? Tags { get; set; }

        public string? SeoDescription { get; set; }

        public DateTime? DateModified { get; set; }
        public bool IsPaid { get; set; }
        public double RoyaltyAmount { get; set; }
        public PostStatusEnum Status { get; set; }
    }
}