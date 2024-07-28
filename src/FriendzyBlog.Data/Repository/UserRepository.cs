namespace FriendzyBlog.Data.Repository
{
    public class UserRepository(FriendzyBlogContext dbContext, MAuthInfoContext authContext) : MRepository<MUser>(dbContext, authContext), IUserRepository
    {
        public async Task<UserDto> CreateUserAsync(CreateUpdateUserRequest request)
        {
            MUser user = new()
            {
                UserName = request.UserName,
                EmailAddress = request.EmailAddress,
                Name = request.Name,
                Surname = request.Surname,
                Password = request.Password,
                PhoneNumber = request.PhoneNumber,
                IsActive = request.IsActive,
                NormalizedUserName = request.UserName.ToUpperInvariant(),
                NormalizedEmailAddress = request.EmailAddress.ToUpperInvariant()
            };

            _ = await _dbBaseContext.AddAsync(user);
            _ = await _dbBaseContext.SaveChangesAsync();

            return new UserDto
            {
                Id = user.Id,
                UserName = user.UserName,
                EmailAddress = user.EmailAddress,
                Name = user.Name,
                Surname = user.Surname,
                PhoneNumber = user.PhoneNumber,
                IsEmailConfirmed = user.IsEmailConfirmed,
                IsActive = user.IsActive,
                CreationTime = user.CreationTime
            };
        }

        public async Task<bool> DeleteUserAsync(Guid id)
        {
            MUser? user = await Queryable.FirstOrDefaultAsync(x => x.EntityId == id);
            if (user == null)
            {
                return false;
            }

            _ = _dbBaseContext.Remove(user);
            int result = await _dbBaseContext.SaveChangesAsync();
            return result > 0;
        }

        public Task<UserDto> LoginAsync(LoginRequest request)
        {
            throw new System.NotImplementedException();
        }

        public async Task<bool> UpdateUserAsync(Guid id, CreateUpdateUserRequest request)
        {
            MUser? user = await Queryable.FirstOrDefaultAsync(x => x.EntityId == id);
            if (user == null)
            {
                return false;
            }

            user.UserName = request.UserName;
            user.EmailAddress = request.EmailAddress;
            user.Name = request.Name;
            user.Surname = request.Surname;
            user.Password = request.Password;
            user.PhoneNumber = request.PhoneNumber;
            user.IsActive = request.IsActive;
            user.NormalizedUserName = request.UserName.ToUpperInvariant();
            user.NormalizedEmailAddress = request.EmailAddress.ToUpperInvariant();

            _ = _dbBaseContext.Update(user);
            int result = await _dbBaseContext.SaveChangesAsync();
            return result > 0;
        }
    }
}