using BulkyWebRazorCore.Data;
using BulkyWebRazorCore.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BulkyWebRazorCore.Pages.Categories
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _dbContext;
        public List<Category> lstCategories { get; set; }  
        public IndexModel(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void OnGet()
        {
            lstCategories = _dbContext.Category.ToList();
        }
    }
}
