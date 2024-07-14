namespace FriendzyBlog.Core.Domain.Content
{
    [Table("PostCategories")]
    [Index(nameof(Slug), IsUnique = true)]
    public class PostCategory
    {
        [Key]
        public Guid Id { get; set; }

        [MaxLength(250)]
        public string Name { set; get; } = string.Empty;

        [Column(TypeName = "varchar(250)")]
        public string Slug { set; get; } = string.Empty;

        public Guid? ParentId { set; get; }
        public bool IsActive { set; get; }
        public DateTime DateCreated { set; get; }
        public DateTime? DateModified { set; get; }

        [MaxLength(160)]
        public string? SeoDescription { set; get; }

        public int SortOrder { set; get; }
    }
}