using System.ComponentModel.DataAnnotations;
using System;
using MyNews.Domains;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace MyNews.Models
{
    public class CommentsViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public long? CommentId { get; set; }

        [Required(ErrorMessage = "Напишите сообщение")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        public virtual ICollection<Article> ArticlesOfComments { get; set; }

        public CommentsViewModel()
        {

        }

        public CommentsViewModel(Comment comment)
        {
            CommentId = comment.CommentId;
            Description = comment.Description;
            ArticlesOfComments = comment.ArticlesOfComments;
        }
    }
}
