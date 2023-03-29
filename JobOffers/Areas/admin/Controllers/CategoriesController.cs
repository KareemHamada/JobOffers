using Bl;
using Domains;
using JobOffers.Utilites;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JobOffers.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("admin")]
    //[Route("admin")]
    public class CategoriesController : Controller
    {
        ICategories _clsCategory;
        public CategoriesController(ICategories clsCategory)
        {
            _clsCategory = clsCategory;
        }
        public IActionResult List()
        {
            return View(_clsCategory.GetAll());
        }


        public IActionResult Edit(int? categoryId)
        {
            var category = new Category();
            if (categoryId != null)
                category = _clsCategory.GetById(Convert.ToInt32(categoryId));

            return View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Save(Category category, List<IFormFile> Files)
        {
            if (!ModelState.IsValid)
                return View("Edit", category);

            if(Files.Count != 0)
                category.ImageName = await Helper.UploadImage(Files, "Categories");

            _clsCategory.Save(category);
            return RedirectToAction("List");
        }


        public IActionResult Delete(int categoryId)
        {
            _clsCategory.Delete(categoryId);
            return RedirectToAction("List");
        }
    }
}
