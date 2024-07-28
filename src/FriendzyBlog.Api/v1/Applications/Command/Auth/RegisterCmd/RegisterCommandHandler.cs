namespace FriendzyBlog.Api.v1.Applications.Command.Auth.RegisterCmd
{
    public class RegisterCommandHandler(
        IUserRepository userRepository,
        IUserRoleQueries userRoleQueries,
        IUserRoleRepository userRoleRepository,
        IUserQueries userQueries,
        IRolesQueries rolesQueries,
        MTokenInfo jwtConfig,
        IMapper mapper,
        ILoginTokenRepository loginTokenRepository)
        : IRequestHandler<RegisterCommand, MResponse<RegisterResponse>>
    {
        public async Task<MResponse<RegisterResponse>> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            MResponse<RegisterResponse> result = new();

            try
            {
                await userRepository.ExecuteTransactionAsync(async () =>
                {
                    MUser newUser = mapper.Map<MUser>(request);
                    newUser.SetNormalizedNames();
                    if (!newUser.IsValid())
                    {
                        result.AddApiErrorMessage(StatusCodes.Status400BadRequest.ToString(), ["Data register invalid!"]);
                        return result;
                    }

                    MUser? existingUser = await userQueries.GetByUserNameAsync(request.UserName);
                    if (existingUser is not null)
                    {
                        result.AddApiErrorMessage(StatusCodes.Status400BadRequest.ToString(), ["Username already exists"]);
                        return result;
                    }

                    string hashedPassword = MPasswordHelper.HashPassword(request.Password, out string salt);
                    newUser.Password = hashedPassword;
                    newUser.Salf = salt;

                    _ = userRepository.Add(newUser);
                    _ = await userRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);

                    // Get the user ID after saving
                    long userId = newUser.Id;

                    RoleDto? userRole = await rolesQueries.GetByNameAsync(StaticRoleNames.Host.User);
                    if (userRole is null)
                    {
                        result.AddApiErrorMessage(StatusCodes.Status400BadRequest.ToString(), ["User role not found"]);
                        return result;
                    }

                    MUserRole? existingUserRole = await userRoleQueries.GetByUserIdAndRoleIdAsync(userId, userRole.Id);
                    if (existingUserRole is null)
                    {
                        _ = userRoleRepository.Add(new MUserRole { UserId = userId, RoleId = userRole.Id });
                    }

                    _ = await userRoleRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);

                    DateTime refreshExpirationTime = DateTime.UtcNow.AddMinutes(SystemConst.RefreshTokenExpirationMinutes);
                    MUserModel userModel = new(userId.ToString(), newUser.EntityId.ToString(), newUser.UserName, [userRole.Name]);
                    string accessToken = MJwtTokenHelper.GenerateJwtToken(jwtConfig, userModel, null);
                    string refreshToken = MJwtTokenHelper.GenerateJwtToken(jwtConfig, userModel, refreshExpirationTime);

                    MUserToken loginToken = new(userId, ProviderNameConst.System, SystemConst.RefreshToken, refreshToken, refreshExpirationTime);
                    _ = loginTokenRepository.Add(loginToken);
                    _ = await loginTokenRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);

                    result.Result = new RegisterResponse
                    {
                        AccessToken = accessToken,
                        RefreshToken = refreshToken,
                        Id = userId,
                        UserName = newUser.UserName,
                        EmailAddress = newUser.EmailAddress,
                        Name = newUser.Name,
                        Surname = newUser.Surname,
                        PhoneNumber = newUser.PhoneNumber,
                        IsEmailConfirmed = newUser.IsEmailConfirmed,
                        IsActive = newUser.IsActive,
                        CreationTime = newUser.CreationTime
                    };

                    return result;
                });
            }
            catch (Exception ex)
            {
                result.AddApiErrorMessage(StatusCodes.Status500InternalServerError.ToString(), ["An error occurred while processing your request.", ex.Message]);
            }

            return result;
        }
    }
}