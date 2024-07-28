namespace FriendzyBlog.Core.Queries
{
    public interface IUserRoleQueries : IMQueries<MUserRole>
    {
        Task<IEnumerable<MUserRole>> GetByUserIdAsync(long userId);

        Task<IEnumerable<MUserRole>> GetByRoleIdAsync(long roleId);

        Task<MUserRole?> GetByUserIdAndRoleIdAsync(long userId, long roleId);
    }
}