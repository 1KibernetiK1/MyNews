using System.ComponentModel.DataAnnotations;
using System;
using MyNews.Domains;
using Microsoft.AspNetCore.Identity;

namespace MyNews.Models
{
    public class CommentsViewModel
    {
        public string Description { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;

        [Key]
        public long? CommentId { get; set; }
        public IdentityUser AuthorId { get; set; }
        public Article PostId { get; set; }

        public CommentsViewModel()
        {

        }

        public CommentsViewModel(Comment model)
        {
            Description= model.Description;
            Date= model.Date;
            CommentId = (long?)model.CommentId;
            AuthorId = model.AuthorId;
            PostId = model.PostId;
        }
    }
}
