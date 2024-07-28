namespace FriendzyBlog.Data.Repository
{
    public class UserRoleRepository(FriendzyBlogContext dbContext, MAuthInfoContext authContext) : MRepository<MUserRole>(dbContext, authContext), IUserRoleRepository
    {
        public async Task<bool> AssignUserToRole(CreateOrUpdateUserRoleRequest request)
        {
            MUserRole userRole = new()
            {
                UserId = request.UserId,
                RoleId = (int)request.RoleId
            };

            _ = await _dbBaseContext.AddAsync(userRole);
            bool result = await _dbBaseContext.SaveChangesAsync() > 0;
            return result;
        }

        public async Task<bool> DeleteUserFromRole(CreateOrUpdateUserRoleRequest request)
        {
            MUserRole? userRole = await Queryable
                .FirstOrDefaultAsync(ur => ur.UserId == request.UserId && ur.RoleId == request.RoleId);

            if (userRole == null)
            {
                return false;
            }

            _ = _dbBaseContext.Remove(userRole);
            bool result = await _dbBaseContext.SaveChangesAsync() > 0;
            return result;
        }

        public async Task<bool> UpdateUserToRole(CreateOrUpdateUserRoleRequest request)
        {
            MUserRole? userRole = await Queryable
                .FirstOrDefaultAsync(ur => ur.UserId == request.UserId && ur.RoleId == request.RoleId);

            if (userRole == null)
            {
                return await AssignUserToRole(request);
            }

            userRole.RoleId = (int)request.RoleId;
            _ = _dbBaseContext.Update(userRole);
            bool result = await _dbBaseContext.SaveChangesAsync() > 0;
            return result;
        }
    }
}