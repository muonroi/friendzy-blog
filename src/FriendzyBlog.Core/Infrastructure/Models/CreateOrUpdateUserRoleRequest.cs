namespace FriendzyBlog.Core.Infrastructure.Models
{
    public record CreateOrUpdateUserRoleRequest
    {
        public long UserId { get; set; }
        public long RoleId { get; set; }
    }
}