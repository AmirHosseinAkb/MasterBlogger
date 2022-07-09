using MB.Application.Contract.ArticleCategory;
using MB.Domain.ArticleCategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MB.Presentation.Areas.Administration.Pages.ArticleCategoryManagement
{
    public class ListModel : PageModel
    {
        private readonly  IArticleCategoryApplication _articleCategoryApplication;

        public ListModel(IArticleCategoryApplication articleCategoryApplication)
        {
            _articleCategoryApplication = articleCategoryApplication;
        }

        public List<ArticleCategoryViewModel> ArticleCategories { get; set; }

        public void OnGet()
        {
            ArticleCategories = _articleCategoryApplication.List();
        }


        public IActionResult OnPostActivate(long id)
        {
            _articleCategoryApplication.Activate(id);
            return RedirectToPage("List");
        }

        public IActionResult OnPostRemove(long id)
        {
            _articleCategoryApplication.Remove(id);
            return RedirectToPage("List");
        }
    }
}
