using BulkyWebRazorCore.Data;
using BulkyWebRazorCore.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BulkyWebRazorCore.Pages.Categories
{
    [BindProperties]
    public class EditCategoryModel : PageModel
    {
        private readonly ApplicationDbContext _dbContext;
        public Category Category { get; set; }  
        public EditCategoryModel(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void OnGet(int? id)
        {
            if(id != null && id!= 0)
            {
                Category=_dbContext.Category.Find(id);
            }
        }
        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                _dbContext.Category.Update(Category);
                _dbContext.SaveChanges();
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
