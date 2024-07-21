namespace FriendzyBlog.Core.Enums
{
    public enum PostActivityLogEnum
    {
        /// <summary>
        /// The post activity log note must be less than 500 characters.
        /// </summary>
        POSTACTIVITYLOG01,

        /// <summary>
        /// The post activity log post id is required.
        /// </summary>
        POSTACTIVITYLOG02,

        /// <summary>
        /// The post activity log user id is required.
        /// </summary>
        POSTACTIVITYLOG03,
    }
}