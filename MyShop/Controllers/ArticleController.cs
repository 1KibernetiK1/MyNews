using Microsoft.AspNetCore.Mvc;
using MyNews.Domains;
using MyNews.Models;
using MyShop.Abstract;
using System.Linq;

namespace MyNews.Controllers
{
    public class ArticleController : Controller
    {
        private readonly IRepository<Article> _repositoryArticle;
        private readonly IRepository<Rubric> _repositoryRubric;

        public ArticleController(IRepository<Rubric> repositoryRubric, IRepository<Article> repositoryArticle)
        {
            _repositoryRubric = repositoryRubric;
            _repositoryArticle = repositoryArticle;
        }

        public IActionResult List()
        {
            var productsSample = _repositoryArticle
                .GetList()
                .OrderBy(p => p.ArticleId)
                .Take(20)
                .Select(e => new ArticleShortModel(e));

            return View(productsSample);
        }

        public IActionResult Details(long id)
        {
            var entity = _repositoryArticle.Read(id);
            var model = new ArticlesViewModel(entity);

            return View(model);
        }

    }
}
