using System;
using BulkyBook.MvcControllers.CategoryMvcController;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace BulkyBook.AppApi.Controllers.Category
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class CategoryController : Controller
    {
        private readonly CategoryMvcController _categoryMvcController;

        public CategoryController(CategoryMvcController categoryMvcController)
        {
            _categoryMvcController = categoryMvcController;
        }

        [HttpGet]
        [EnableCors("MyPolicy")]
        public IActionResult GetAll()
        {
            return Ok(new { data = _categoryMvcController.GetAll() });
        }

    }
}
