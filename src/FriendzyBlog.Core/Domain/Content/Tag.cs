namespace FriendzyBlog.Core.Domain.Content
{
    [Table("Tags")]
    public class Tag : EntityBase
    {
        [Required(ErrorMessage = nameof(TagEnum.TAG01))]
        [MaxLength(100, ErrorMessage = nameof(TagEnum.TAG02))]
        public string Name { get; set; } = string.Empty;
    }
}