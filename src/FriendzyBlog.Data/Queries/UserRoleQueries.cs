namespace FriendzyBlog.Data.Queries
{
    public class UserRoleQueries(FriendzyBlogContext dbContext, MAuthInfoContext authContext) : MQuery<MUserRole>(dbContext, authContext), IUserRoleQueries
    {
        public async Task<IEnumerable<MUserRole>> GetByRoleIdAsync(long roleId)
        {
            return await dbContext.UserRoles
                .Where(userRole => userRole.RoleId == roleId)
                .ToListAsync()
                .ConfigureAwait(false);
        }

        public async Task<MUserRole?> GetByUserIdAndRoleIdAsync(long userId, long roleId)
        {
            return await dbContext.UserRoles
                .FirstOrDefaultAsync(userRole => userRole.UserId == userId && userRole.RoleId == roleId)
                .ConfigureAwait(false);
        }

        public async Task<IEnumerable<MUserRole>> GetByUserIdAsync(long userId)
        {
            return await dbContext.UserRoles
                .Where(userRole => userRole.UserId == userId)
                .ToListAsync()
                .ConfigureAwait(false);
        }
    }
}