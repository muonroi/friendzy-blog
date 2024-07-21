namespace FriendzyBlog.Core.Enums
{
    public enum SeriesEnum
    {
        /// <summary>
        /// The series name is required.
        /// </summary>
        SERIES01,

        /// <summary>
        /// The series name must be less than 250 characters.
        /// </summary>
        SERIES02,

        /// <summary>
        /// The series slug is required.
        /// </summary>
        SERIES03,

        /// <summary>
        /// The series slug must be less than 250 characters.
        /// </summary>
        SERIES04,

        /// <summary>
        /// The series description must be less than 160 characters.
        /// </summary>
        SERIES05,

        /// <summary>
        /// The series sort order is required.
        /// </summary>
        SERIES06,

        /// <summary>
        /// The series seo description must be less than 250 characters.
        /// </summary>
        SERIES07,

        /// <summary>
        /// The series thumbnail must be less than 250 characters.
        /// </summary>
        SERIES08,

        /// <summary>
        /// The author user id is required.
        /// </summary>
        SERIES09
    }
}