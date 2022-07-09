using MB.Application.Contract.Article;
using MB.Application.Contract.ArticleCategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MB.Presentation.Areas.Administration.Pages.ArticleManagement
{
    public class CreateModel : PageModel
    {
        private readonly IArticleApplication _articleApplication;
        private readonly IArticleCategoryApplication _articleCategoryApplication;

        [BindProperty]
        public CreateArticleCommand Command { get; set; }
        public List<SelectListItem> ArticleCategories { get; set; }
        public CreateModel(IArticleApplication articleApplication,IArticleCategoryApplication articleCategoryApplication)
        {
            _articleApplication = articleApplication;
            _articleCategoryApplication = articleCategoryApplication;
        }
        public void OnGet()
        {
            ArticleCategories = _articleCategoryApplication.List().Select(c => new SelectListItem()
            {
                Text = c.Title,
                Value = c.Id.ToString()
            }).ToList();
        }

        public IActionResult OnPost()
        {
            _articleApplication.Create(Command);
            return RedirectToPage("List");
        }
    }
}
