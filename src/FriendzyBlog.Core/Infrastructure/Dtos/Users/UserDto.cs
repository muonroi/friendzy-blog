namespace FriendzyBlog.Core.Infrastructure.Dtos.Users
{
    namespace FriendzyBlog.Data.DTOs
    {
        public class UserDto
        {
            public long Id { get; set; }
            public string UserName { get; set; } = string.Empty;
            public string EmailAddress { get; set; } = string.Empty;
            public string Name { get; set; } = string.Empty;
            public string Surname { get; set; } = string.Empty;
            public string PhoneNumber { get; set; } = string.Empty;
            public bool IsEmailConfirmed { get; set; }
            public bool IsActive { get; set; }
            public DateTime CreationTime { get; set; }
        }
    }
}