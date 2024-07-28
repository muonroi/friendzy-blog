namespace FriendzyBlog.Core.Infrastructure.Models.Users
{
    public class CreateUpdateUserRequest
    {
        public string UserName { get; init; } = string.Empty;
        public string EmailAddress { get; init; } = string.Empty;
        public string Name { get; init; } = string.Empty;
        public string Surname { get; init; } = string.Empty;
        public string Password { get; init; } = string.Empty;
        public string PhoneNumber { get; init; } = string.Empty;
        public bool IsActive { get; init; }
    }
}