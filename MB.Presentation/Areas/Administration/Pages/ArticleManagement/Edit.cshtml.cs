using MB.Application.Contract.Article;
using MB.Application.Contract.ArticleCategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MB.Presentation.Areas.Administration.Pages.ArticleManagement
{
    public class EditModel : PageModel
    {
        private readonly IArticleApplication _articleApplication;
        private readonly IArticleCategoryApplication _articleCategoryApplication;
        public List<SelectListItem> ArticleCategories { get; set; }

        [BindProperty]
        public EditArticleCommand Command { get; set; }
        public EditModel(IArticleApplication articleApplication,IArticleCategoryApplication articleCategoryApplication)
        {
            _articleApplication = articleApplication;
            _articleCategoryApplication = articleCategoryApplication;
        }


        public void OnGet(long id)
        {
            ArticleCategories = _articleCategoryApplication.List().Select(c => new SelectListItem()
                {Text = c.Title, Value = c.Id.ToString()}).ToList();

            Command = _articleApplication.GetArticleForEdit(id);
        }

        public IActionResult OnPost()
        {
            _articleApplication.Edit(Command);
            return RedirectToPage("List");
        }
    }
}
