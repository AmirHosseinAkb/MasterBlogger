using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MB.Domain.ArticleCategory
{
    public interface IArticleCategoryRepository
    {
        List<ArticleCategory> GetAll();
        void Add(ArticleCategory entity);
        ArticleCategory Get(long id);
        void Save();
        bool IsExist(string title);
    }
}
