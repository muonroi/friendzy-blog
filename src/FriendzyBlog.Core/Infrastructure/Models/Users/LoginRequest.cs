namespace FriendzyBlog.Core.Infrastructure.Models.Users
{
    public class LoginRequest
    {
        public string Password { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
    }
}