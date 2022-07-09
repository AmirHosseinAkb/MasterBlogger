using MB.Application.Contract.ArticleCategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MB.Presentation.Areas.Administration.Pages.ArticleCategoryManagement
{
    public class EditModel : PageModel
    {
        private readonly  IArticleCategoryApplication _articleCategoryApplication;
        [BindProperty]
        public RenameArticleCategoryCommand RenameArticleCategoryCommand { get; set; }
        public EditModel(IArticleCategoryApplication articleCategoryApplication)
        {
            _articleCategoryApplication = articleCategoryApplication;
        }
        public void OnGet(int id)
        {
            RenameArticleCategoryCommand = _articleCategoryApplication.Get(id);
        }

        public IActionResult OnPost()
        {
            _articleCategoryApplication.Rename(RenameArticleCategoryCommand);
            return RedirectToPage("List");
        }
    }
}
