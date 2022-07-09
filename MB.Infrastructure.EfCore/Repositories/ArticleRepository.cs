using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MB.Domain.Article;
using MB.Domain.ArticleCategory;
using Microsoft.EntityFrameworkCore;

namespace MB.Infrastructure.EfCore.Repositories
{
    public class ArticleRepository:IArticleRepository
    {
        private readonly MasterBloggerContext _context;

        public ArticleRepository(MasterBloggerContext context)
        {
            _context = context;
        }

        public List<Article> GetAllArticles()
        {
            return _context.Articles
                .Include(a=>a.ArticleCategory)
                .OrderByDescending(a=>a.ArticleId)
                .ToList();
        }

        public void Create(Article article)
        {
            _context.Articles.Add(article);
            _context.SaveChanges();
        }

        public Article GetArticle(long id)
        {
            return _context.Articles.Find(id);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
