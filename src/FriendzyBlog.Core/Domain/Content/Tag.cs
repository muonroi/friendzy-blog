﻿namespace FriendzyBlog.Core.Domain.Content
{
    [Table("Tags")]
    public class Tag
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;
    }
}