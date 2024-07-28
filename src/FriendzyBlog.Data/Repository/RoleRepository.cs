namespace FriendzyBlog.Data.Repository
{
    public class RoleRepository(FriendzyBlogContext dbContext, MAuthInfoContext authContext) : MRepository<MRole>(dbContext, authContext), IRoleRepository
    {
        public async Task<bool> CreateRoleAsync(CreateUpdateRoleRequest request)
        {
            MRole role = new()
            {
                Name = request.Name,
                DisplayName = request.DisplayName,
                IsStatic = request.IsStatic,
                IsDefault = request.IsDefault,
            };

            _ = await _dbBaseContext.AddAsync(role);
            int result = await _dbBaseContext.SaveChangesAsync();
            return result > 0;
        }

        public async Task<bool> DeleteRoleAsync(long id)
        {
            MRole? role = await Queryable.FirstOrDefaultAsync(x => x.Id == id);
            if (role is null)
            {
                return false;
            }
            _ = _dbBaseContext.Remove(role);
            int result = await _dbBaseContext.SaveChangesAsync();
            return result > 0;
        }

        public async Task<bool> UpdateRoleAsync(long id, CreateUpdateRoleRequest request)
        {
            MRole? role = await Queryable.FirstOrDefaultAsync(x => x.Id == id);
            if (role is null)
            {
                return false;
            }
            role.Name = request.Name;
            role.DisplayName = request.DisplayName;
            role.IsStatic = request.IsStatic;
            role.IsDefault = request.IsDefault;

            _ = _dbBaseContext.Remove(role);
            int result = await _dbBaseContext.SaveChangesAsync();
            return result > 0;
        }
    }
}