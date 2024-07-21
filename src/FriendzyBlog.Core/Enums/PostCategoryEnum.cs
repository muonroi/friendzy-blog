namespace FriendzyBlog.Core.Enums
{
    public enum PostCategoryEnum
    {
        /// <summary>
        /// The post category name is required.
        /// </summary>
        POSTCATEGORY01,

        /// <summary>
        /// The post category name must be less than 250 characters.
        /// </summary>
        POSTCATEGORY02,

        /// <summary>
        /// The post category slug is required.
        /// </summary>
        POSTCATEGORY03,

        /// <summary>
        /// The post category slug must be less than 250 characters.
        /// </summary>
        POSTCATEGORY04,

        /// <summary>
        /// The post category description must be less than 160 characters.
        /// </summary>
        POSTCATEGORY05,

        /// <summary>
        /// The post category sort order is required.
        /// </summary>
        POSTCATEGORY06,
    }
}