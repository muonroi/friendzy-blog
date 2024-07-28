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

            MRole? adminRoleForHost = _context.Roles.IgnoreQueryFilters().FirstOrDefault(r => r.Name == StaticRoleNames.Host.Admin);
            if (adminRoleForHost == null)
            {
                adminRoleForHost = _context.Roles.Add(new MRole(StaticRoleNames.Host.Admin, StaticRoleNames.Host.Admin) { IsStatic = true, IsDefault = true, CreatedDateTS = DateTime.UtcNow.GetTimeStamp() }).Entity;

                _ = _context.Roles.Add(new MRole(StaticRoleNames.Host.User, StaticRoleNames.Host.User) { IsStatic = true, IsDefault = true, CreatedDateTS = DateTime.UtcNow.GetTimeStamp() });

                _ = _context.SaveChanges();
            }
        }
    }
}