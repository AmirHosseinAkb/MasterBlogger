using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MB.Domain.ArticleCategory.Services
{
    public interface IArticleCategoryValidatorService
    {
        void IsExistArticleCategory(string title);
    }

    public class ArticleCategoryValidatorService : IArticleCategoryValidatorService
    {
        private readonly IArticleCategoryRepository _articleCategoryRepository;

        public ArticleCategoryValidatorService(IArticleCategoryRepository articleCategoryRepository)
        {
            _articleCategoryRepository = articleCategoryRepository;
        }
        public void IsExistArticleCategory(string title)
        {
            if (_articleCategoryRepository.IsExist(title))
            {
                throw new Exception();
            }
        }
    }
}
