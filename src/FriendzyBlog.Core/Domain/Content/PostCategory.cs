namespace FriendzyBlog.Core.Domain.Content
{
    [Table("PostCategories")]
    public class PostCategory : MEntity
    {
        [Required(ErrorMessage = nameof(PostCategoryEnum.POSTCATEGORY01))]
        [MaxLength(250, ErrorMessage = nameof(PostCategoryEnum.POSTCATEGORY02))]
        public string Name { set; get; } = string.Empty;

        [Column(TypeName = "varchar(250)")]
        [Required(ErrorMessage = nameof(PostCategoryEnum.POSTCATEGORY03))]
        [MaxLength(250, ErrorMessage = nameof(PostCategoryEnum.POSTCATEGORY04))]
        public string Slug { set; get; } = string.Empty;

        public Guid? ParentId { set; get; }

        public bool IsActive { set; get; }

        [MaxLength(160, ErrorMessage = nameof(PostCategoryEnum.POSTCATEGORY05))]
        public string? SeoDescription { set; get; }

        public int SortOrder { set; get; }
    }
}