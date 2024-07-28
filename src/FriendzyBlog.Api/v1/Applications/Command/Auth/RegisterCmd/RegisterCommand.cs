namespace FriendzyBlog.Api.v1.Applications.Command.Auth.RegisterCmd
{
    public class RegisterCommand : CreateUpdateUserRequest, IRequest<MResponse<RegisterResponse>>
    {
    }
}