namespace FriendzyBlog.Core.Queries
{
    public interface ILoginTokenQueries : IMQueries<MUserToken>
    {
        Task<MUserToken?> GetByProviderNameAsync(string providerName);
    }
}