using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;

namespace MyNews.Domains
{
    public class Comment
    {
        public string Description { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;

        [Key]
        public long? CommentId { get; set; }
        public IdentityUser AuthorId { get; set; }
        public Article PostId { get; set; }

      
    }
}
