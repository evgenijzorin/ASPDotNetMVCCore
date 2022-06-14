using Microsoft.AspNetCore.Mvc;
using TaskLesson_3.Models;

namespace TaskLesson_3.Controllers
{
    public class CatalogController : Controller
    {
        private static Catalog _catalog = new();
        /// <summary>
        /// Вывести категории
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Categories()
        {
            return View(_catalog);
        }
        /// <summary>
        /// Добавить категорию
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Categories(Category model)
        {
            _catalog.Categories.Add(model);
            return View(_catalog);
        }

        /// <summary>
        /// Вывести продукты
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Products()
        {
            return View(_catalog);
        }

        /// <summary>
        /// Добавить продукт
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Products(Product model)
        {
            _catalog.Products.Add(model);
            return View(_catalog);
        }





    }
}
