namespace FriendzyBlog.Core.Domain.Content
{
    [Table("PostActivityLogs")]
    public class PostActivityLog : MEntity
    {
        [Required(ErrorMessage = nameof(PostActivityLogEnum.POSTACTIVITYLOG02))]
        public Guid PostId { get; set; }

        public PostStatusEnum FromStatus { set; get; }

        public PostStatusEnum ToStatus { set; get; }

        [MaxLength(500, ErrorMessage = nameof(PostActivityLogEnum.POSTACTIVITYLOG01))]
        public string? Note { set; get; }

        [Required(ErrorMessage = nameof(PostActivityLogEnum.POSTACTIVITYLOG03))]
        public Guid UserId { get; set; }
    }
}