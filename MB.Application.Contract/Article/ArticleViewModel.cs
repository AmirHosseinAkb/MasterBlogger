using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace MB.Application.Contract.Article
{
    public class ArticleViewModel
    {
        public long ArticleId { get; set; }
        public string Title { get; set; }
        public string CreationDate { get; set; }
        public string ArticleCategory { get; set; }
        public bool IsDeleted { get; set; }
    }
}
