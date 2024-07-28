namespace FriendzyBlog.Api.v1.Applications.Command.PostCmd
{
    public class CreatePostCommand : CreateUpdatePostRequest, IRequest<MResponse<PostDto>>
    {
    }
}