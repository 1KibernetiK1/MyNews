using MyNews.Domains;
using MyShop.Abstract;
using MyShop.DataAccessLayer;
using System.Collections.Generic;
using System.Linq;

namespace MyNews.DataAccessLayer
{
    public class RubricSqlRepository : IRepository<Rubric>
    {
        private readonly ApplicationDbContext _context;

        public RubricSqlRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Create(Rubric model)
        {
            var existing = FindByName(model.Name);
            if (existing == null)
            {
                _context.Rubrics.Add(model);
                _context.SaveChanges();
            }
            else
            {
                model.RubricId = existing.RubricId;
            }
        }

        public void Delete(long id)
        {
            var entry = _context.Rubrics.Find(id);
            _context.Rubrics.Remove(entry);
            _context.SaveChanges();
        }

        public Rubric FindByName(string name)
        {
            return _context.Rubrics
                .FirstOrDefault(c => c.Name == name);
        }

        public IEnumerable<Rubric> GetList()
        {
            return _context.Rubrics;
        }

        public Rubric Read(long id)
        {
            var entry = _context.Rubrics.Find(id);
            return entry;
        }

        public void Update(Rubric model)
        {
            var entry = _context.Rubrics.Find(model.RubricId);
            _context.Entry(entry).CurrentValues.SetValues(model);
            _context.SaveChanges();
        }
    }
}
