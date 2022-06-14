using Microsoft.AspNetCore.Mvc;
using TaskLesson_3.Models;


namespace TaskLesson_3.Controllers
{
    public class CatalogController : Controller
    {
        private static TheadSafeCatalog _theadSafeCatalog = new();
        /// <summary>
        /// Вывести категории
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Categories()
        {
            return View(_theadSafeCatalog);
        }
        /// <summary>
        /// Добавить категорию
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Categories(TheadSafeCatalog.Category model)
        {
            _theadSafeCatalog.Add(model);
            return View(_theadSafeCatalog);
        }

        /// <summary>
        /// Вывести продукты
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Products()
        {
            return View(_theadSafeCatalog);
        }

        /// <summary>
        /// Добавить продукт
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Products(TheadSafeCatalog.Product model)
        {
            _theadSafeCatalog.Add(model);   
            return View(_theadSafeCatalog);
        }





    }
}
