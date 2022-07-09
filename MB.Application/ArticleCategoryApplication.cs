using System.Globalization;
using MB.Application.Contract.ArticleCategory;
using MB.Domain.ArticleCategory;
using MB.Domain.ArticleCategory.Services;

namespace MB.Application
{
    public class ArticleCategoryApplication:IArticleCategoryApplication
    {
        private readonly IArticleCategoryRepository _articleCategoryRepository;
        private readonly  IArticleCategoryValidatorService _articleCategoryValidatorService;

        public ArticleCategoryApplication(IArticleCategoryRepository articleCategoryRepository, IArticleCategoryValidatorService articleCategoryValidatorService)
        {
            _articleCategoryRepository = articleCategoryRepository;
            _articleCategoryValidatorService = articleCategoryValidatorService;
        }
        public List<ArticleCategoryViewModel> List()
        {
            var articleCategories = _articleCategoryRepository.GetAll();
            return articleCategories.Select(c => new ArticleCategoryViewModel()
            {
                Id=c.Id,
                Title = c.Title,
                CreationDate = c.CreationDate.ToString(CultureInfo.InvariantCulture),
                IsDeleted = c.IsDeleted,
                
            }).ToList();
        }

        public void Add(CreateArticleCategoryCommand command)
        {
            var articleCategory = new ArticleCategory(command.Title,_articleCategoryValidatorService);
            _articleCategoryRepository.Add(articleCategory);
        }

        public void Rename(RenameArticleCategoryCommand command)
        {
            var articleCategory = _articleCategoryRepository.Get(command.Id);
            articleCategory.Rename(command.Title);
            _articleCategoryRepository.Save();
        }

        public RenameArticleCategoryCommand Get(long id)
        {
            var articleCategory = _articleCategoryRepository.Get(id);
            return new RenameArticleCategoryCommand()
            {
                Id = articleCategory.Id,
                Title = articleCategory.Title
            };
        }

        public void Activate(long id)
        {
            var articleCategory=_articleCategoryRepository.Get(id);
            articleCategory.Activate();
            _articleCategoryRepository.Save();
        }

        public void Remove(long id)
        {
            var articleCategory = _articleCategoryRepository.Get(id);
            articleCategory.Remove();
            _articleCategoryRepository.Save();
        }
    }
}
