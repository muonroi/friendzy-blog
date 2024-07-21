namespace FriendzyBlog.Core.Enums
{
    public enum PostEnum
    {
        /// <summary>
        /// The post name is required.
        /// </summary>
        POST01,

        /// <summary>
        /// The post name must be less than 250 characters.
        /// </summary>
        POST02,

        /// <summary>
        /// The slug is required.
        /// </summary>
        POST03,

        /// <summary>
        /// The slug must be less than 250 characters.
        /// </summary>
        POST04,

        /// <summary>
        /// The post description must be less than 500 characters.
        /// </summary>
        POST05,

        /// <summary>
        /// The post category is required.
        /// </summary>
        POST06,

        /// <summary>
        /// The post category id is required.
        /// </summary>
        POST07,

        /// <summary>
        /// The post category thumbnail must be less than 500 characters.
        /// </summary>
        POST08,

        /// <summary>
        /// The post author user id is required.
        /// </summary>
        POST09,

        /// <summary>
        /// The post source must be less than 128 characters.
        /// </summary>
        POST10,

        /// <summary>
        /// The post tags must be less than 250 characters.
        /// </summary>
        POST11,

        /// <summary>
        /// The post seo description must be less than 160 characters.
        /// </summary>
        POST12,
    }
}