namespace FriendzyBlog.Data.Seed
{
    public class HostRoleAndUserCreator(FriendzyBlogContext context)
    {
        private readonly FriendzyBlogContext _context = context;

        public void Create()
        {
            CreateHostRoleAndUsers();
        }

        private void CreateHostRoleAndUsers()
        {
            //Admin role for host

            AppRole? adminRoleForHost = _context.Roles.IgnoreQueryFilters().FirstOrDefault(r => r.Name == StaticRoleNames.Host.Admin);
            if (adminRoleForHost == null)
            {
                adminRoleForHost = _context.Roles.Add(new AppRole(StaticRoleNames.Host.Admin, StaticRoleNames.Host.Admin) { IsStatic = true, IsDefault = true, CreatedDateTS = DateTime.UtcNow.GetTimeStamp() }).Entity;
                _ = _context.SaveChanges();
            }

            //admin user for host

            AppUser? adminUserForHost = _context.Users.IgnoreQueryFilters().FirstOrDefault(u => u.UserName == AppUser.AdminUserName);
            if (adminUserForHost == null)
            {
                AppUser user = new()
                {
                    UserName = AppUser.AdminUserName,
                    Name = "admin",
                    Surname = "admin",
                    EmailAddress = "admin@muonroi.com",
                    IsEmailConfirmed = true,
                    ShouldChangePasswordOnNextLogin = false,
                    IsActive = true,
                    Password = "AM4OLBpptxBYmM79lGOX9egzZk3vIQU3d/gFCJzaBjAPXzYIK3tQ2N7X4fcrHtElTw==", //123qwe,
                    CreationTime = DateTime.UtcNow
                };

                user.SetNormalizedNames();

                adminUserForHost = _context.Users.Add(user).Entity;
                _ = _context.SaveChanges();

                //Assign Admin role to admin user
                _ = _context.UserRoles.Add(new AppUserRole(adminUserForHost.Id, adminRoleForHost.Id));
                _ = _context.SaveChanges();

                //User account of admin user
                _ = _context.UserAccounts.Add(new AppUserAccount
                {
                    UserId = adminUserForHost.Id,
                    UserName = AppUser.AdminUserName,
                    EmailAddress = adminUserForHost.EmailAddress,
                    CreatedDateTS = DateTime.UtcNow.GetTimeStamp()
                });

                _ = _context.SaveChanges();
            }
        }
    }
}