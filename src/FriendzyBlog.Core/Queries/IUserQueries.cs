namespace FriendzyBlog.Core.Queries
{
    public interface IUserQueries : IMQueries<MUser>
    {
        Task<MUser?> GetByUserNameAsync(string userName);

        Task<MUser?> GetByEmailAsync(string email);

        Task<MPagedResult<UserInListDto>> GetAllPagingAsync(string keyword, int pageIndex, int pageSize);
    }
}