using MyNews.Domains;
using MyShop.Abstract;
using MyShop.DataAccessLayer;
using System.Collections.Generic;

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
            throw new System.NotImplementedException();
        }

        public void Delete(long id)
        {
            throw new System.NotImplementedException();
        }

        public Article FindByName(string name)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Article> GetList()
        {
            throw new System.NotImplementedException();
        }

        public Article Read(long id)
        {
            throw new System.NotImplementedException();
        }

        public void Update(Article model)
        {
            throw new System.NotImplementedException();
        }
    }
}
