using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MB.Application.Contract.Article
{
    public class EditArticleCommand:CreateArticleCommand
    {
        public long ArticleId { get; set; }
    }
}
