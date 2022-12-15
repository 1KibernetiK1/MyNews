using Microsoft.AspNetCore.Mvc;
using MyNews.Domains;
using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace MyNews.Models
{
    public class ArticleShortModel
    {
        [HiddenInput(DisplayValue = false)]
        public long ArticleId { get; set; }

        [Display(Name = "Название")]
        public string Title { get; set; }

        [Display(Name = "Дата создания")]
        [DataType(DataType.DateTime)]
        public DateTime CreationDate { get; set; }

        public ArticleShortModel()
        { }

        public ArticleShortModel(Article entity)
        {
            ArticleId = entity.ArticleId;
            Title = entity.Title;
            CreationDate = entity.CreationDate;
        }
    }
}
