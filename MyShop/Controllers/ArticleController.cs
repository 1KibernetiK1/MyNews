using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyNews.Domains;
using MyNews.Models;
using MyShop.Abstract;
using System.Data;
using System.Linq;

namespace MyNews.Controllers
{
    //[Authorize(Roles = "Administrator,Redactor")]
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

        public IActionResult Create(long id)
        {
            var manager = _repositoryArticle.Read(id);

            return View(manager);
        }

        [HttpPost]
        public IActionResult Create(ArticlesViewModel model)
        {
            if (ModelState.IsValid)
            {
                Article article = new Article()
                {
                    ArticleId = model.ArticleId,
                    Title = model.Title,
                    ArticleRubric = model.Rubric,
                    CreationDate= model.CreationDate,
                    Description= model.Description,
                    ImageUrl= model.ImageUrl
                };

                _repositoryArticle.Create(article);

                return RedirectToAction("List", "Article");
            }

            return View(model);
        }

        public IActionResult DeleteArticle(long id)
        {
            _repositoryArticle.Delete(id);

            return RedirectToAction("List", "Article");
        }

        public IActionResult EditArticle(long id)
        {
            var article = new ArticlesViewModel(_repositoryArticle.Read(id));

            return View(article);
        }

        [HttpPost]
        public IActionResult EditArticle(ArticlesViewModel model)
        {
            Article manager = new Article()
            {
                ArticleId = model.ArticleId,
                Title = model.Title,
                ArticleRubric = model.Rubric,
                CreationDate = model.CreationDate,
                Description = model.Description,
                ImageUrl = model.ImageUrl

            };

            if (ModelState.IsValid)
            {
                _repositoryArticle.Update(manager);
                return RedirectToAction("List", new { id = model.ArticleId });
            }

            return View();
        }

    }
}
