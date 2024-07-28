namespace FriendzyBlog.Core.Repository
{
    public interface IUserRoleRepository : IMRepository<MUserRole>
    {
        Task<bool> AssignUserToRole(CreateOrUpdateUserRoleRequest request);

        Task<bool> UpdateUserToRole(CreateOrUpdateUserRoleRequest request);

        Task<bool> DeleteUserFromRole(CreateOrUpdateUserRoleRequest request);
    }
}