namespace FriendzyBlog.Api.v1.Applications.Command.Auth.LoginCmd
{
    public class LoginCommand : LoginRequest, IRequest<MResponse<LoginResponse>>
    {
    }
}