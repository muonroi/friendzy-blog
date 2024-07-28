namespace FriendzyBlog.Core.Repository
{
    public interface IRoleRepository : IMRepository<MRole>
    {
        Task<bool> CreateRoleAsync(CreateUpdateRoleRequest request);

        Task<bool> UpdateRoleAsync(long id, CreateUpdateRoleRequest request);

        Task<bool> DeleteRoleAsync(long id);
    }
}