namespace FriendzyBlog.Data.Queries
{
    public class LoginTokenQueries(FriendzyBlogContext dbContext, MAuthInfoContext authContext) : MQuery<MUserToken>(dbContext, authContext), ILoginTokenQueries
    {
        public async Task<MUserToken?> GetByProviderNameAsync(string providerName)
        {
            MUserToken? appUserToken = await Queryable.FirstOrDefaultAsync(x => x.LoginProvider == providerName);
            return appUserToken;
        }
    }
}