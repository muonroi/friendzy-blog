namespace FriendzyBlog.Core.Infrastructure.Models.Users
{
    public class LoginResponse : UserDto
    {
        public string AccessToken { get; set; } = string.Empty;
        public string RefreshToken { get; set; } = string.Empty;
    }
}