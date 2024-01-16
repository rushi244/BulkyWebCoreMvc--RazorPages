using BulkyWebRazorCore.Data;
using BulkyWebRazorCore.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BulkyWebRazorCore.Pages.Categories
{
    [BindProperties]
    public class DeleteCategoryModel : PageModel
    {
        private readonly ApplicationDbContext _dbContext;
        public Category category { get; set; }
        public DeleteCategoryModel(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void OnGet(int? id)
        {
            if(id != null && id != 0)
            {
                category = _dbContext.Category.Find(id);
            }
        }
        public IActionResult OnPost()
        {
            Category? obj = _dbContext.Category.Find(category.Id);
            if (obj is null)
            {
                return NotFound();
            }
            _dbContext.Category.Remove(obj);
            _dbContext.SaveChanges();
           // TempData["success"] = "Category deleted Successfull..";
            return RedirectToPage("Index");
        }
    }
}
