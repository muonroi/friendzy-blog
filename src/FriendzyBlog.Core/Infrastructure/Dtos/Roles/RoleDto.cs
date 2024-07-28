namespace FriendzyBlog.Core.Infrastructure.Dtos.Roles
{
    public class RoleDto
    {
        public long Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string DisplayName { get; set; } = string.Empty;
        public bool IsStatic { get; set; }
        public bool IsDefault { get; set; }
        public string NormalizedName { get; set; } = string.Empty;
        public string ConcurrencyStamp { get; set; } = string.Empty;
    }
}