using Microsoft.AspNetCore.Mvc;
using MyNews.Domains;
using System;
using System.ComponentModel.DataAnnotations;

namespace MyNews.Models
{
    public class ArticlesViewModel
    {
        public Rubric Rubric { get; set; }

        [HiddenInput(DisplayValue = false)]
        public long? ArticleId { get; set; }

        [Required]
        [Display(Name = "Заголовок новости")]
        public string Title { get; set; }

        [Required]
        [Display(Name = "Описание новости")]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Дата созданиея новости")]
        [DataType(DataType.DateTime)]
        public DateTime CreationDate { get; set; } = DateTime.Now;

        [Display(Name = "Картинка новости")]
        [DataType(DataType.ImageUrl)]
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
