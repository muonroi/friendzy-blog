namespace FriendzyBlog.Data.Repository
{
    public class PostRepository(FriendzyBlogContext dbContext, MAuthInfoContext authContext) : MRepository<Post>(dbContext, authContext), IPostRepository
    {
        public async Task<bool> CreatePostAsync(CreateUpdatePostRequest request)
        {
            Post post = new()
            {
                Name = request.Name,
                Slug = request.Slug,
                Description = request.Description,
                CategoryId = request.CategoryId,
                Thumbnail = request.Thumbnail,
                Content = request.Content,
                AuthorUserId = request.AuthorUserId,
                Source = request.Source,
                Tags = request.Tags,
                SeoDescription = request.SeoDescription,
                ViewCount = request.ViewCount,
                IsPaid = request.IsPaid,
                RoyaltyAmount = request.RoyaltyAmount,
                Status = request.Status
            };

            _ = await _dbBaseContext.AddAsync(post);
            int result = await _dbBaseContext.SaveChangesAsync();
            return result > 0;
        }

        public async Task<bool> DeletePostAsync(Guid id)
        {
            Post? post = await Queryable.FirstOrDefaultAsync(x => x.EntityId == id);
            if (post is null)
            {
                return false;
            }
            _ = _dbBaseContext.Remove(post);
            int result = await _dbBaseContext.SaveChangesAsync();
            return result > 0;
        }

        public async Task<bool> UpdatePostAsync(Guid id, CreateUpdatePostRequest request)
        {
            Post? post = await Queryable.FirstOrDefaultAsync(x => x.EntityId == id);
            if (post is null)
            {
                return false;
            }
            post.Name = request.Name;
            post.Slug = request.Slug;
            post.Description = request.Description;
            post.CategoryId = request.CategoryId;
            post.Thumbnail = request.Thumbnail;
            post.Content = request.Content;
            post.Source = request.Source;
            post.Tags = request.Tags;
            post.SeoDescription = request.SeoDescription;
            post.ViewCount = request.ViewCount;
            post.IsPaid = request.IsPaid;
            post.RoyaltyAmount = request.RoyaltyAmount;
            post.Status = request.Status;

            _ = _dbBaseContext.Remove(post);
            int result = await _dbBaseContext.SaveChangesAsync();
            return result > 0;
        }
    }
}