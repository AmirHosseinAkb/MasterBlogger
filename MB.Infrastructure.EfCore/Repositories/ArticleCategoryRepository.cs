using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MB.Domain.ArticleCategory;

namespace MB.Infrastructure.EfCore.Repositories
{
    public class ArticleCategoryRepository:IArticleCategoryRepository
    {
        private readonly MasterBloggerContext _context;

        public ArticleCategoryRepository(MasterBloggerContext context)
        {
            _context = context;
        }
        public List<ArticleCategory> GetAll()
        {
            return _context.ArticleCategories.OrderByDescending(c=>c.Id).ToList();
        }

        public void Add(ArticleCategory entity)
        {
            _context.ArticleCategories.Add(entity);
            Save();
        }

        public ArticleCategory Get(long id)
        {
            return _context.ArticleCategories.Find(id);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public bool IsExist(string title)
        {
            return _context.ArticleCategories.Any(c => c.Title == title);
        }
    }
}
