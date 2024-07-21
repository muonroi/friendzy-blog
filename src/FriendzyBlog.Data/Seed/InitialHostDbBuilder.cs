namespace FriendzyBlog.Data.Seed
{
    public class InitialHostDbBuilder(FriendzyBlogContext context)
    {
        private readonly FriendzyBlogContext _context = context;

        public void Create()
        {
            new DefaultLanguagesCreator(_context).Create();
            new HostRoleAndUserCreator(_context).Create();

            _ = _context.SaveChanges();
        }
    }
}