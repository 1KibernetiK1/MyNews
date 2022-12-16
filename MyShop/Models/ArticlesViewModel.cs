using MyNews.Domains;
using System;

namespace MyNews.Models
{
    public class ArticlesViewModel
    {
        public Rubric Rubric { get; set; }

        public long ArticleId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime CreationDate { get; set; }

        public string ImageUrl { get; set; }

        public ArticlesViewModel()
        {

        }

        public ArticlesViewModel(Article article)
        {
            ArticleId = article.ArticleId;

            Title = article.Title;
            Description = article.Description;
            CreationDate = article.CreationDate;
            ImageUrl = article.ImageUrl;
            Rubric = article.ArticleRubric;
        }
    }
}
