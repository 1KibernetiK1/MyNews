using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyNews.Domains
{
    [Table("Articles")]
    public class Article
    {
        [Key]
        public long? ArticleId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime CreationDate { get; set; }

        public string ImageUrl { get; set; }

        public Rubric ArticleRubric { get; set; }

        public Comment Comments { get; set; }

    }
}
