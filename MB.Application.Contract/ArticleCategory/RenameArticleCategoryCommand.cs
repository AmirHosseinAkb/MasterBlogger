using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MB.Application.Contract.ArticleCategory
{
    public class RenameArticleCategoryCommand:CreateArticleCategoryCommand
    {
        public long Id { get; set; }
    }
}
