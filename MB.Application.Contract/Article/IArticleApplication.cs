using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MB.Application.Contract.Article
{
    public interface IArticleApplication
    {
        List<ArticleViewModel> GetArticlesList();
        void Create(CreateArticleCommand command);
        void Edit(EditArticleCommand command);
        EditArticleCommand GetArticleForEdit(long id);
    }
}
