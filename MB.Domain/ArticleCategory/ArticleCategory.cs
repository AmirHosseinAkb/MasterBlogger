using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MB.Domain.ArticleCategory.Services;

namespace MB.Domain.ArticleCategory
{
    public class ArticleCategory
    {
        public long Id { get; private set; }
        public string Title { get; set; }
        public DateTime CreationDate { get; set; }
        public bool IsDeleted { get; set; }
        public List<Article.Article> Articles { get; set; }

        public void AvoidFromNullTitle(string title)
        {
            if (string.IsNullOrWhiteSpace(title))
                throw new ArgumentNullException();
        }

        protected ArticleCategory()
        {
            
        }

        public ArticleCategory(string title,IArticleCategoryValidatorService articleCategoryValidatorService)
        {
            AvoidFromNullTitle(title);
            articleCategoryValidatorService.IsExistArticleCategory(title);
            Title=title;
            IsDeleted = false;
            CreationDate = DateTime.Now;
            Articles=new List<Article.Article>();
        }



        public void Rename(string title)
        {
            AvoidFromNullTitle(title);
            Title = title;
        }

        public void Activate()
        {
            IsDeleted=false;
        }

        public void Remove()
        {
            IsDeleted = true;
        }
    }
}
