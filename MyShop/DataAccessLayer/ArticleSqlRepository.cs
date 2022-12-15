using Microsoft.EntityFrameworkCore;
using MyNews.Domains;
using MyShop.Abstract;
using MyShop.DataAccessLayer;
using System.Collections.Generic;
using System.Linq;

namespace MyNews.DataAccessLayer
{
    public class ArticleSqlRepository : IRepository<Article>
    {
        private readonly ApplicationDbContext _context;

        public ArticleSqlRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Create(Article model)
        {
            _context.Articles.Add(model);
            _context.SaveChanges();
        }

        public void Delete(long id)
        {
            var entry = _context.Articles.Find(id);
            _context.Articles.Remove(entry);
            _context.SaveChanges();
        }

        public Article FindByName(string name)
        {
           return _context.Articles
                .FirstOrDefault(c => c.Title == name);
        }

        public IEnumerable<Article> GetList()
        {
            return _context
              .Articles
              .Include(p => p.ArticleRubric);
        }

        public Article Read(long id)
        {
            var entry = _context
              .Articles
              .Include(p => p.ArticleRubric)
              .FirstOrDefault(p => p.ArticleId == id);
            return entry;
        }

        public void Update(Article model)
        {
            var entry = _context.Articles.Find(model.ArticleId);
            _context.Entry(entry).CurrentValues.SetValues(model);
            entry.ArticleRubric = model.ArticleRubric;
            _context.SaveChanges();
        }
    }
}
