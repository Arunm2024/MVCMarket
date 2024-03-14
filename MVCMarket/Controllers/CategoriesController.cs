using Microsoft.AspNetCore.Mvc;
using MVCMarket.Models;

namespace MVCMarket.Controllers
{
    public class CategoriesController : Controller
    {
        public IActionResult Index()
        {
            var category= CategoriesRepository.GetCategory();
            return View(category);
        }
        public IActionResult Edit(int? id)
        {
            var category = CategoriesRepository.GetCategoryById(id.HasValue?id.Value:0);
            //var category= new Category() { CategoryId=id.HasValue? id.Value : 0 };
            return View(category);
        }
        [HttpPost]
        public IActionResult Edit(Category category) 
        {
            if (ModelState.IsValid)
            {
                CategoriesRepository.UpdateCategory(category.CategoryId, category);
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }
    }
}
