using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata;

namespace MyNews.Domains
{
    [Table("Comments")]
    public class Comment
    {
        [Key]
        public long? CommentId { get; set; }

        public string Description { get; set; }

        public virtual ICollection<Article> ArticlesOfComments { get; set; }


    }
}
