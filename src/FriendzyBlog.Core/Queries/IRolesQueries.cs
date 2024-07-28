namespace FriendzyBlog.Core.Queries
{
    public interface IRolesQueries : IMQueries<MRole>
    {
        Task<IEnumerable<RoleDto>> GetByUserIdAsync(long userId);

        Task<RoleDto?> GetByNameAsync(string name);

        Task<MPagedResult<RoleInListDto>> GetAllPagingAsync(string keyword, int pageIndex, int pageSize);
    }
}