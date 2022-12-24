using Microsoft.AspNetCore.Mvc;
using MyNews.Domains;
using MyNews.Models;
using MyShop.Abstract;

namespace MyNews.Components
{
    public class CommentViewComponent : ViewComponent
    {
        private readonly IRepository<Comment> repository;

        public CommentViewComponent(IRepository<Comment> repository)
        {
            this.repository = repository;
        }

        public IViewComponentResult Create(long id)
        {
            var comment = repository.Read(id);

            return View(comment);
        }

        [HttpPost]
        public IViewComponentResult Create(CommentsViewModel model)
        {
            if (ModelState.IsValid)
            {
                Comment comment = new Comment()
                {
                    CommentId = model.CommentId,
                    Description = model.Description,
                    ArticlesOfComments = model.ArticlesOfComments,
                };

                repository.Create(comment);

            }

            return View(model);
        }
    }
}
