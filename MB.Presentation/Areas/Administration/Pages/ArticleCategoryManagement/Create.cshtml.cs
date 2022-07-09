using MB.Application.Contract.ArticleCategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MB.Presentation.Areas.Administration.Pages.ArticleCategoryManagement
{
    public class CreateModel : PageModel
    {
        private readonly  IArticleCategoryApplication _articleCategoryApplication;

        public CreateModel(IArticleCategoryApplication articleCategoryApplication)
        {
            _articleCategoryApplication = articleCategoryApplication;
        }
        public void OnGet()
        {
        }

        public IActionResult OnPost(CreateArticleCategoryCommand command)
        {
            _articleCategoryApplication.Add(command);
            return RedirectToPage("List");
        }
    }
}
