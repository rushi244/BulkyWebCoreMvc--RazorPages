using BulkyWebCoreMvc.Data;
using BulkyWebCoreMvc.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyWebCoreMvc.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public CategoryController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult Index()
        {
            List<Category> objlstCategory = _dbContext.Category.ToList();
            return View(objlstCategory);
        }
        public IActionResult CreateCategory()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateCategory(Category _category)
        {
            //if(_category.Name==_category.DisplayOrder.ToString())
            //{
            //    ModelState.AddModelError("", "Cannot same");
            //}
            if (ModelState.IsValid) {
                _dbContext.Category.Add(_category);
                _dbContext.SaveChanges();
                TempData["success"] = "Category Created Successfull..";
                return RedirectToAction("Index");

            }
            return View();
        }
        public IActionResult EditCategory(int? id)
        {
            if (id == null && id == 0)
            {
                return NotFound();
            }
            Category? category = _dbContext.Category.Find(id);
            //Category? category1 = _dbContext.Category.FirstOrDefault(c => c.Id == id);
            //Category? category2 = _dbContext.Category.Where(c => c.Id == id).FirstOrDefault();
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }
        [HttpPost]
        public IActionResult EditCategory(Category _category)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Category.Update(_category);
                _dbContext.SaveChanges();
                TempData["success"] = "Category updated Successfull..";
                return RedirectToAction("Index");

            }
            return View();
        }

        public IActionResult DeleteCategory(int? id)
        {
            if (id == null && id == 0)
            {
                return NotFound();
            }
            Category? category = _dbContext.Category.Find(id);
            //Category? category1 = _dbContext.Category.FirstOrDefault(c => c.Id == id);
            //Category? category2 = _dbContext.Category.Where(c => c.Id == id).FirstOrDefault();
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }
        [HttpPost,ActionName("DeleteCategory")]
        public IActionResult DeleteCategoryPost(int? id)
        {
            Category? _category = _dbContext.Category.Find(id);
            if (_category is null)
            {
                return NotFound(); 

            }
            _dbContext.Category.Remove(_category);
            _dbContext.SaveChanges();
            TempData["success"] = "Category deleted Successfull..";
            return RedirectToAction("Index");

        }
    }
}
