namespace FriendzyBlog.Core.Infrastructure.Dtos.Roles
{
    public class RoleInListDto
    {
        public long Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string DisplayName { get; set; } = string.Empty;
        public bool IsStatic { get; set; }
        public bool IsDefault { get; set; }
    }
}