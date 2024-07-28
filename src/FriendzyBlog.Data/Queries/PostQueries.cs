namespace FriendzyBlog.Data.Queries
{
    public class PostQueries(FriendzyBlogContext dbContext, MAuthInfoContext authContext, IMapper mapper, IRolesQueries rolesQueries) : MQuery<Post>(dbContext, authContext), IPostQueries
    {
        public async Task<MResponse<IEnumerable<Post>>> GetPopularPostAsync(int count)
        {
            MResponse<IEnumerable<Post>> mResult = new()
            {
                Result = await Queryable.OrderByDescending(x => x.ViewCount).Take(count).ToListAsync()
            };
            return mResult;
        }

        public async Task<MResponse<MPagedResult<PostInListDto>>> GetPostPaging(string? keyword, Guid? categoryId, int pageIndex, int pageSize)
        {
            MResponse<MPagedResult<PostInListDto>> mResult = new();
            MAuthInfoContext authInfo = _authContext!;
            MUser? user = await dbContext.Users.FindAsync(authInfo.CurrentUserId.ToString());
            if (user == null)
            {
                mResult.AddApiErrorMessage(
                         nameof(PostEnum.POST13),
                         [MHelpers.GenerateErrorResult(keyword ?? string.Empty, authInfo.CorrelationId)]
                         );
                return mResult;
            }
            IEnumerable<RoleDto> roles = await rolesQueries.GetByUserIdAsync(user.Id);

            if (!roles.Any())
            {
                mResult.AddApiErrorMessage(
                         nameof(PostEnum.POST14),
                         [MHelpers.GenerateErrorResult(keyword ?? string.Empty, authInfo.CorrelationId)]
                         );
                return mResult;
            }

            IQueryable<Post> query = _dbSet.AsQueryable();
            if (!string.IsNullOrWhiteSpace(keyword))
            {
                query = query.Where(x => x.Name.Contains(keyword));
            }
            if (categoryId.HasValue)
            {
                query = query.Where(x => x.CategoryId == categoryId.Value);
            }

            int totalRow = await query.CountAsync();

            query = query.OrderByDescending(x => x.CreatedDateTS)
               .Skip((pageIndex - 1) * pageSize)
               .Take(pageSize);

            mResult.Result = new MPagedResult<PostInListDto>
            {
                Items = await mapper.ProjectTo<PostInListDto>(query).ToListAsync(),
                CurrentPage = pageIndex,
                RowCount = totalRow,
                PageSize = pageSize
            };

            return mResult;
        }
    }
}