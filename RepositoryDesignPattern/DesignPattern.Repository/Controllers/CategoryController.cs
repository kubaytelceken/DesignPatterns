using Microsoft.AspNetCore.Mvc;
using RepositoryDesignPattern.Business.Abstract;
using RepositoryDesignPattern.Entitites.Concrete;

namespace DesignPattern.Repository.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public IActionResult Index()
        {
            var categoryList = _categoryService.TGetAll();
            return View(categoryList);
        }

        [HttpGet]
        public IActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddCategory(Category category)
        {
            _categoryService.TInsert(category);
            return RedirectToAction("Index");
        }


       public IActionResult DeleteCategory(int id)
        {
            var category = _categoryService.TGetById(id);
            _categoryService.TDelete(category);
            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult UpdateCategory(int id)
        {
            var category = _categoryService.TGetById(id);
            return View(category);
        }

        [HttpPost]
        public IActionResult UpdateCategory(Category category)
        {
            _categoryService.TUpdate(category);
            return RedirectToAction("Index");
        }

    }
}
