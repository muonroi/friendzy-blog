namespace FriendzyBlog.Core.Infrastructure.Dtos.Users
{
    public class UserInListDto
    {
        public long Id { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string EmailAddress { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public bool IsActive { get; set; }
    }
}