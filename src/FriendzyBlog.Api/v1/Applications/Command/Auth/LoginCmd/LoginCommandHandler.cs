namespace FriendzyBlog.Api.v1.Applications.Command.Auth.LoginCmd
{
    public class LoginCommandHandler(IUserQueries userQueries, IRolesQueries rolesQueries, MTokenInfo jwtConfig)
        : IRequestHandler<LoginCommand, MResponse<LoginResponse>>
    {
        public async Task<MResponse<LoginResponse>> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            MResponse<LoginResponse> result = new();

            MUser? user = await userQueries.GetByUserNameAsync(request.Username);
            if (user is null)
            {
                result.AddApiErrorMessage(StatusCodes.Status404NotFound.ToString(), ["User not found"]);
                return result;
            }

            bool passwordIsValid = MPasswordHelper.VerifyPassword(request.Password, user.Password, user.Salf!);
            if (!passwordIsValid)
            {
                result.AddApiErrorMessage(StatusCodes.Status400BadRequest.ToString(), ["Username or password invalid"]);
                return result;
            }

            IEnumerable<RoleDto> userRoles = await rolesQueries.GetByUserIdAsync(user.Id);
            MUserModel userModel = new(user.Id.ToString(), user.EntityId.ToString(), user.UserName, userRoles.Select(x => x.Name));
            string accessToken = MJwtTokenHelper.GenerateJwtToken(jwtConfig, userModel, null);
            string refreshToken = MJwtTokenHelper.GenerateJwtToken(jwtConfig, userModel, DateTime.UtcNow.AddMinutes(SystemConst.RefreshTokenExpirationMinutes));

            result.Result = new LoginResponse
            {
                Id = user.Id,
                UserName = user.UserName,
                EmailAddress = user.EmailAddress,
                Name = user.Name,
                Surname = user.Surname,
                PhoneNumber = user.PhoneNumber,
                IsEmailConfirmed = user.IsEmailConfirmed,
                IsActive = user.IsActive,
                CreationTime = user.CreationTime,
                AccessToken = accessToken,
                RefreshToken = refreshToken
            };

            return result;
        }
    }
}