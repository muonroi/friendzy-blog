namespace FriendzyBlog.Data.Queries
{
    public class RoleQueries(FriendzyBlogContext dbContext, MAuthInfoContext authContext, IUserRoleQueries userRoleQueries) : MQuery<MRole>(dbContext, authContext), IRolesQueries
    {
        public async Task<MPagedResult<RoleInListDto>> GetAllPagingAsync(string keyword, int pageIndex, int pageSize)
        {
            IQueryable<MRole> query = dbContext.Roles;

            if (!string.IsNullOrEmpty(keyword))
            {
                query = query.Where(role => role.Name.Contains(keyword) || role.DisplayName.Contains(keyword));
            }

            int totalItems = await query.CountAsync().ConfigureAwait(false);

            List<MRole> roles = await query.Skip((pageIndex - 1) * pageSize)
                                   .Take(pageSize)
                                   .ToListAsync()
                                   .ConfigureAwait(false);

            List<RoleInListDto> roleDtos = roles.Select(role => new RoleInListDto
            {
                Id = role.Id,
                Name = role.Name,
                DisplayName = role.DisplayName,
                IsStatic = role.IsStatic,
                IsDefault = role.IsDefault
            }).ToList();

            return new MPagedResult<RoleInListDto>
            {
                CurrentPage = pageIndex,
                PageSize = pageSize,
                RowCount = totalItems,
                Items = roleDtos
            };
        }

        public async Task<RoleDto?> GetByNameAsync(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return null;
            }

            MRole? role = await dbContext.Roles
                                      .FirstOrDefaultAsync(r => r.Name == name)
                                      .ConfigureAwait(false);

            return role == null
                ? null
                : new RoleDto
                {
                    Id = role.Id,
                    Name = role.Name,
                    DisplayName = role.DisplayName,
                    IsStatic = role.IsStatic,
                    IsDefault = role.IsDefault,
                    NormalizedName = role.NormalizedName,
                    ConcurrencyStamp = role.ConcurrencyStamp
                };
        }

        public async Task<IEnumerable<RoleDto>> GetByUserIdAsync(long userId)
        {
            IEnumerable<MUserRole> userRoles = await userRoleQueries.GetByUserIdAsync(userId).ConfigureAwait(false);

            List<RoleDto> roleDtos = [];

            foreach (MUserRole userRole in userRoles)
            {
                MRole? role = await dbContext.Roles
                                          .FirstOrDefaultAsync(r => r.Id == userRole.RoleId)
                                          .ConfigureAwait(false);

                if (role != null)
                {
                    roleDtos.Add(new RoleDto
                    {
                        Id = role.Id,
                        Name = role.Name,
                        DisplayName = role.DisplayName,
                        IsStatic = role.IsStatic,
                        IsDefault = role.IsDefault,
                        NormalizedName = role.NormalizedName,
                        ConcurrencyStamp = role.ConcurrencyStamp
                    });
                }
            }

            return roleDtos;
        }
    }
}