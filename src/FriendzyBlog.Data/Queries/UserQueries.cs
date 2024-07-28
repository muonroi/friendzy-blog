namespace FriendzyBlog.Data.Queries
{
    public class UserQueries(FriendzyBlogContext dbContext, MAuthInfoContext authContext) : MQuery<MUser>(dbContext, authContext), IUserQueries
    {
        public async Task<MPagedResult<UserInListDto>> GetAllPagingAsync(string keyword, int pageIndex, int pageSize)
        {
            IQueryable<MUser> query = dbContext.Users;

            if (!string.IsNullOrEmpty(keyword))
            {
                query = query.Where(x => x.UserName.Contains(keyword) || x.EmailAddress.Contains(keyword));
            }

            int totalItems = await query.CountAsync().ConfigureAwait(false);
            List<MUser> users = await query.Skip((pageIndex - 1) * pageSize)
                                   .Take(pageSize)
                                   .ToListAsync()
                                   .ConfigureAwait(false);

            List<UserInListDto> userDtos = users.Select(user => new UserInListDto
            {
                Id = user.Id,
                UserName = user.UserName,
                EmailAddress = user.EmailAddress,
                FullName = $"{user.Name} {user.Surname}",
                IsActive = user.IsActive
            }).ToList();

            return new MPagedResult<UserInListDto>
            {
                CurrentPage = pageIndex,
                PageSize = pageSize,
                RowCount = totalItems,
                Items = userDtos
            };
        }

        public async Task<MUser?> GetByEmailAsync(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                return null;
            }

            MUser? user = await dbContext.Users.FirstOrDefaultAsync(x => x.EmailAddress == email)
                                                 .ConfigureAwait(false);

            return user ?? null;
        }

        public async Task<MUser?> GetByUserNameAsync(string userName)
        {
            if (string.IsNullOrEmpty(userName))
            {
                return null;
            }

            MUser? user = await dbContext.Users.FirstOrDefaultAsync(x => x.UserName == userName)
                                                 .ConfigureAwait(false);

            return user ?? null;
        }
    }
}