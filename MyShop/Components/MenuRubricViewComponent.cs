using Microsoft.AspNetCore.Mvc;
using MyNews.Domains;
using MyShop.Abstract;
using System.Linq;

namespace MyNews.Components
{
    [ViewComponent]
    public class MenuRubricViewComponent :
        ViewComponent
    {
        private readonly IRepository<Rubric> repository;

        public MenuRubricViewComponent(IRepository<Rubric> repository)
        {
            this.repository = repository;
        }

        public IViewComponentResult Invoke()
        {
            var categoriesNameList = repository
                .GetList()
                .Select(x => x.Name);

            return View(categoriesNameList);
        }
    }
}
