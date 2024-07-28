namespace FriendzyBlog.Core.Infrastructure.Models.Roles
{
    public record CreateUpdateRoleRequest
    {
        public long Id { get; init; }
        public string Name { get; init; } = string.Empty;
        public string DisplayName { get; init; } = string.Empty;
        public bool IsStatic { get; init; }
        public bool IsDefault { get; init; }
    }
}