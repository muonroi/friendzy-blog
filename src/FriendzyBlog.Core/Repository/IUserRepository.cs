namespace FriendzyBlog.Core.Repository
{
    public interface IUserRepository : IMRepository<MUser>
    {
        Task<UserDto> LoginAsync(LoginRequest request);

        Task<UserDto> CreateUserAsync(CreateUpdateUserRequest request);

        Task<bool> UpdateUserAsync(Guid id, CreateUpdateUserRequest request);

        Task<bool> DeleteUserAsync(Guid id);
    }
}