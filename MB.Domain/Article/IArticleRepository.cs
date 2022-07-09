using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MB.Domain.Article
{
    public interface IArticleRepository
    {
        List<Article> GetAllArticles();
        void Create(Article article);
        Article GetArticle(long id);
        void Save();
    }
}
