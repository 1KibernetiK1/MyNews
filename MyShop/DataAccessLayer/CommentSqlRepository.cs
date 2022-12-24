using Microsoft.EntityFrameworkCore;
using MyNews.Domains;
using MyShop.Abstract;
using MyShop.DataAccessLayer;
using System.Collections.Generic;
using System.Linq;

namespace MyNews.DataAccessLayer
{
    public class CommentSqlRepository : IRepository<Comment>
    {

        private readonly ApplicationDbContext _context;

        public CommentSqlRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Create(Comment model)
        {
            _context.Comments.Add(model);
            _context.SaveChanges();
        }

        public void Delete(long id)
        {
            var entry = _context.Comments.Find(id);
            _context.Comments.Remove(entry);
            _context.SaveChanges();
        }

        public Comment FindByName(string name)
        {
            return _context.Comments
              .FirstOrDefault(c => c.Description == name);
        }

        public IEnumerable<Comment> GetList()
        {
            return _context
              .Comments
              .Include(p => p.CommentId);
        }

        public Comment Read(long id)
        {
            var entry = _context
              .Comments
              .Include(p => p.CommentId)
              .FirstOrDefault(p => p.CommentId == id);
            return entry;
        }

        public void Update(Comment model)
        {

            var entry = _context.Comments.Find(model.CommentId);
            _context.Entry(entry).CurrentValues.SetValues(model);
            _context.SaveChanges();
        }
    }
}
