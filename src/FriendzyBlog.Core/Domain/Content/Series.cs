namespace FriendzyBlog.Core.Domain.Content
{
    [Table("Series")]
    public class Series : MEntity
    {
        [Required(ErrorMessage = nameof(SeriesEnum.SERIES01))]
        [MaxLength(250, ErrorMessage = nameof(SeriesEnum.SERIES02))]
        public string Name { get; set; } = string.Empty;

        [MaxLength(250, ErrorMessage = nameof(SeriesEnum.SERIES04))]
        public string? Description { get; set; }

        [Column(TypeName = "varchar(250)")]
        [Required(ErrorMessage = nameof(SeriesEnum.SERIES03))]
        [MaxLength(250, ErrorMessage = nameof(SeriesEnum.SERIES04))]
        public string Slug { get; set; } = string.Empty;

        public bool IsActive { get; set; }

        public int SortOrder { get; set; }

        [MaxLength(250, ErrorMessage = nameof(SeriesEnum.SERIES07))]
        public string? SeoDescription { get; set; }

        [MaxLength(250, ErrorMessage = nameof(SeriesEnum.SERIES08))]
        public string? Thumbnail { set; get; }

        public string? Content { get; set; }

        [Required(ErrorMessage = nameof(SeriesEnum.SERIES09))]
        public Guid AuthorUserId { get; set; }
    }
}