namespace FriendzyBlog.Data
{
    public static class DataSeeder
    {
        public static async Task SeedAsync(this FriendzyBlogContext context)
        {
            PasswordHasher<AppUser> passwordHasher = new();

            Guid rootAdminRoleId = Guid.NewGuid();
            if (!context.Roles.Any())
            {
                _ = await context.Roles.AddAsync(new AppRole()
                {
                    Id = rootAdminRoleId,
                    Name = "Admin",
                    NormalizedName = "ADMIN",
                    DisplayName = "Quản trị viên"
                });
                _ = await context.SaveChangesAsync();
            }

            if (!context.Users.Any())
            {
                Guid userId = Guid.NewGuid();
                AppUser user = new()
                {
                    Id = userId,
                    FirstName = "Toan",
                    LastName = "Tedu",
                    Email = "admin@tedu.com.vn",
                    NormalizedEmail = "ADMIN@TEDU.COM.VN",
                    UserName = "admin",
                    NormalizedUserName = "ADMIN",
                    IsActive = true,
                    SecurityStamp = Guid.NewGuid().ToString(),
                    LockoutEnabled = false,
                    DateCreated = DateTime.Now
                };
                user.PasswordHash = passwordHasher.HashPassword(user, "Admin@123$");
                _ = await context.Users.AddAsync(user);

                _ = await context.UserRoles.AddAsync(new IdentityUserRole<Guid>()
                {
                    RoleId = rootAdminRoleId,
                    UserId = userId,
                });
                _ = await context.SaveChangesAsync();
            }
        }
    }
}