namespace FriendzyBlog.Core.Infrastructure.Dtos.Posts
{
    public class PostInListDto
    {
        public Guid EntityId { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Slug { get; set; } = string.Empty;

        [MaxLength(500)]
        public string? Description { get; set; }

        public string? Thumbnail { get; set; }
        public int ViewCount { get; set; }
        public DateTime DateCreated { get; set; }
    }
}