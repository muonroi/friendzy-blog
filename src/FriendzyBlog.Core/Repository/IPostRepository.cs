namespace FriendzyBlog.Core.Repository
{
    public interface IPostRepository : IMRepository<Post>
    {
        Task<bool> CreatePostAsync(CreateUpdatePostRequest request);

        Task<bool> UpdatePostAsync(Guid id, CreateUpdatePostRequest request);

        Task<bool> DeletePostAsync(Guid id);
    }
}