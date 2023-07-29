using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using RepositoryDesignPattern.Business.Abstract;
using RepositoryDesignPattern.Entitites.Concrete;
using System.Collections.Generic;
using System.Linq;

namespace DesignPattern.Repository.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;

        public ProductController(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }

        public IActionResult Index()
        {
            var productList = _productService.TProductListWithCategory();
            return View(productList);
        }

        [HttpGet]
        public IActionResult AddProduct()
        {

            List<SelectListItem> values = (from x in _categoryService.TGetAll()
                                           select new SelectListItem
                                           {
                                               Text = x.CategoryName,
                                               Value = x.CategoryId.ToString()
                                           }).ToList();
            ViewBag.categoryList = values;
            return View();
        }

        [HttpPost]
        public IActionResult AddProduct(Product product)
        {
            _productService.TInsert(product);
            return RedirectToAction("Index");
        }


        public IActionResult DeleteProduct(int id)
        {
            var product = _productService.TGetById(id);
            _productService.TDelete(product);
            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult UpdateProduct(int id)
        {
            List<SelectListItem> values = (from x in _categoryService.TGetAll()
                                           select new SelectListItem
                                           {
                                               Text = x.CategoryName,
                                               Value = x.CategoryId.ToString()
                                           }).ToList();
            ViewBag.categoryList = values;
            var product = _productService.TGetById(id);
            return View(product);
        }

        [HttpPost]
        public IActionResult UpdateProduct(Product product)
        {
            _productService.TUpdate(product);
            return RedirectToAction("Index");
        }
    }
}
