namespace FriendzyBlog.Core.Domain.Content
{
    [Table("Posts")]
    public class Post : MEntity
    {
        [Required(ErrorMessage = nameof(PostEnum.POST01))]
        [MaxLength(250, ErrorMessage = nameof(PostEnum.POST02))]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = nameof(PostEnum.POST03))]
        [Column(TypeName = "varchar(250)")]
        [MaxLength(250, ErrorMessage = nameof(PostEnum.POST04))]
        public string Slug { get; set; } = string.Empty;

        [MaxLength(500, ErrorMessage = nameof(PostEnum.POST05))]
        public string? Description { get; set; }

        [Required(ErrorMessage = nameof(PostEnum.POST07))]
        public Guid CategoryId { get; set; }

        [MaxLength(500, ErrorMessage = nameof(PostEnum.POST08))]
        public string? Thumbnail { get; set; }

        public string? Content { get; set; }

        [Required(ErrorMessage = nameof(PostEnum.POST09))]
        public Guid AuthorUserId { get; set; }

        [MaxLength(128, ErrorMessage = nameof(PostEnum.POST10))]
        public string? Source { get; set; }

        [MaxLength(250, ErrorMessage = nameof(PostEnum.POST11))]
        public string? Tags { get; set; }

        [MaxLength(160, ErrorMessage = nameof(PostEnum.POST12))]
        public string? SeoDescription { get; set; }

        public int ViewCount { get; set; }

        public bool IsPaid { get; set; }

        public double RoyaltyAmount { get; set; }

        public PostStatusEnum Status { get; set; }
    }
}