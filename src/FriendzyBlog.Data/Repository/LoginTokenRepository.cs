namespace FriendzyBlog.Data.Repository
{
    public class LoginTokenRepository(FriendzyBlogContext dbContext, MAuthInfoContext authContext) : MRepository<MUserToken>(dbContext, authContext), ILoginTokenRepository
    {
    }
}