namespace FriendzyBlog.Core.Infrastructure.Models.Posts
{
    public class CreateUpdatePostRequest
    {
        public string Name { get; init; } = string.Empty;
        public string Slug { get; init; } = string.Empty;
        public string? Description { get; init; }
        public Guid CategoryId { get; init; }
        public string? Thumbnail { get; init; }
        public string? Content { get; init; }
        public Guid AuthorUserId { get; init; }
        public string? Source { get; init; }
        public string? Tags { get; init; }
        public string? SeoDescription { get; init; }
        public int ViewCount { get; init; }
        public bool IsPaid { get; init; }
        public double RoyaltyAmount { get; init; }
        public PostStatusEnum Status { get; init; }
    }
}