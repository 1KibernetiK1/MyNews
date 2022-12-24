using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyNews.Domains;
using System.Threading.Tasks;
using System;
using MyNews.Models;
using MyShop.DataAccessLayer;
using MyShop.Abstract;

namespace MyNews.Controllers
{
    public class CommentController : Controller
    {
        private readonly IRepository<Comment> _repositoryComment;


        public CommentController(IRepository<Comment> repositoryComment)
        {
            _repositoryComment = repositoryComment;
        }

        public IActionResult Create(long id)
        {
            var comment = _repositoryComment.Read(id);

            return View(comment);
        }

        [HttpPost]
        public IActionResult Create(CommentsViewModel model)
        {
            if (ModelState.IsValid)
            {
                Comment comment = new Comment()
                {
                    CommentId= model.CommentId,
                    Description= model.Description,
                    ArticlesOfComments = model.ArticlesOfComments,
                };

                _repositoryComment.Create(comment);

                return RedirectToAction("Details", "Article");
            }

            return View(model);
        }

    }
}
