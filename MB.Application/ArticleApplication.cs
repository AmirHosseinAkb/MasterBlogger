using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MB.Application.Contract.Article;
using MB.Domain.Article;

namespace MB.Application
{
    public class ArticleApplication:IArticleApplication
    {
        private readonly IArticleRepository _articleRepository;

        public ArticleApplication(IArticleRepository articleRepository)
        {
            _articleRepository = articleRepository;
        }
        public List<ArticleViewModel> GetArticlesList()
        {
            return _articleRepository.GetAllArticles().Select(a=>new ArticleViewModel()
            {
                ArticleId = a.ArticleId,
                Title = a.Title,
                IsDeleted = a.IsDeleted,
                ArticleCategory = a.ArticleCategory.Title,
                CreationDate = a.CreationDate.ToString(CultureInfo.InvariantCulture)
            }).ToList();

        }

        public void Create(CreateArticleCommand command)
        {
            var article = new Article(command.Title, command.ShortDescription, command.Image, command.Content,
                command.ArticleCategoryId);
            _articleRepository.Create(article);
        }

        public void Edit(EditArticleCommand command)
        {
            var article = _articleRepository.GetArticle(command.ArticleId);
            article.Edit(command.Title,command.ShortDescription,command.Image,command.Content,command.ArticleCategoryId);
            _articleRepository.Save();
        }

        public EditArticleCommand GetArticleForEdit(long id)
        {
            var article = _articleRepository.GetArticle(id);
            return new EditArticleCommand()
            {
                ArticleId = article.ArticleId,
                ArticleCategoryId = article.ArticleCategoryId,
                Title = article.Title,
                ShortDescription = article.ShortDescription,
                Content = article.Content,
                Image = article.Image
            };
        }
    }
}
