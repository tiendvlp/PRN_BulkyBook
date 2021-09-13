using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BulkyBook.Models;
using Microsoft.AspNetCore.Mvc;
using BulkyBook.MvcControllers.CategoryMvcController;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BulkyBook.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly CategoryMvcController _categoryMvcController;

        public CategoryController(CategoryMvcController categoryController)
        {
            _categoryMvcController = categoryController;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Upsert(int? id)
        {
            Category category = new Category();
            if (id == null)
            {
                return View(category);
            }

            category = _categoryMvcController.Get(id.GetValueOrDefault());

            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }


        [HttpGet]
        public IActionResult GetAll()
        {
            return Json(new { data = _categoryMvcController.GetAll() });
        }
    }

}
