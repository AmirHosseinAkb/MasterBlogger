using MB.Application.Contract.Article;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MB.Presentation.Areas.Administration.Pages.ArticleManagement
{
    public class ListModel : PageModel
    {
        private readonly IArticleApplication _articleApplication;
        public List<ArticleViewModel> ArticleViewModels { get; set; }

        public ListModel(IArticleApplication articleApplication)
        {
            _articleApplication = articleApplication;
        }
        public void OnGet()
        {
            ArticleViewModels = _articleApplication.GetArticlesList();
        }
    }
}
