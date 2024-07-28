namespace FriendzyBlog.Core.Queries
{
    public interface IPostQueries : IMQueries<Post>
    {
        Task<MResponse<IEnumerable<Post>>> GetPopularPostAsync(int count);

        Task<MResponse<MPagedResult<PostInListDto>>> GetPostPaging(string? keyword, Guid? categoryId, int pageIndex, int pageSize);
    }
}