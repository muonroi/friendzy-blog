namespace FriendzyBlog.Api
{
    public class CustomMapper : Profile
    {
        public CustomMapper()
        {
            _ = CreateMap<Post, PostDto>();
            _ = CreateMap<PostDto, Post>();
            _ = CreateMap<Post, PostInListDto>();
            _ = CreateMap<CreatePostCommand, Post>();
            _ = CreateMap<RegisterCommand, MUser>();
        }
    }
}