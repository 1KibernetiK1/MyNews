using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyNews.Domains;
using MyNews.Models;
using MyShop.Abstract;
using System.Data;
using System.Linq;

namespace MyNews.Controllers
{
    public class ArticlePubController : Controller
    {
        private readonly IRepository<Article> _repositoryArticle;
        private readonly IRepository<Rubric> _repositoryRubric;

        public ArticlePubController(IRepository<Rubric> repositoryRubric, IRepository<Article> repositoryArticle)
        {
            _repositoryRubric = repositoryRubric;
            _repositoryArticle = repositoryArticle;
        }

        public IActionResult List()
        {
            var ArticleSample = _repositoryArticle
                .GetList()
                .OrderBy(p => p.ArticleId)
                .Take(20)
                .Select(e => new ArticleShortModel(e));

            return View(ArticleSample);
        }

        public IActionResult Details(long id)
        {
            var entity = _repositoryArticle.Read(id);
            var model = new ArticlesViewModel(entity);

            return View(model);
        }
    }
}
