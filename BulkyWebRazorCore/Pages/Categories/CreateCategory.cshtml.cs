using BulkyWebRazorCore.Data;
using BulkyWebRazorCore.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BulkyWebRazorCore.Pages.Categories
{
    //[BindProperties]
    public class CreateCategoryModel : PageModel
    {
        private readonly ApplicationDbContext _dbContext;
        [BindProperty]
        public Category category { get; set; }
        public CreateCategoryModel(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void OnGet()
        {
        }
        public IActionResult OnPost()
        {
            if(ModelState.IsValid) {

                _dbContext.Category.Add(category);
                _dbContext.SaveChanges();
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
