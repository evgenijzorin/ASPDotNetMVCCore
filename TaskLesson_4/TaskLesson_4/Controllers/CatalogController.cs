using Microsoft.AspNetCore.Mvc;
using TaskLesson_4.Models;
using TaskLesson_4.Servicies.Interfaces;

namespace TaskLesson_3.Controllers
{
    public class CatalogController : Controller
    {
        private readonly IEmailSender _emailSendler;
        public CatalogController(IEmailSender emailSendler)
        {
            _emailSendler = emailSendler;
        }

        private static ThreadSafeCatalog _theadSafeCatalog = new();  

        /// <summary> Вывести категории </summary> 
        [HttpGet]
        public IActionResult Categories()
        {
            return View(_theadSafeCatalog);
        }
        /// <summary> Добавить категорию </summary> 
        [HttpPost]
        public IActionResult Categories(ThreadSafeCatalog.Category model)
        {
            _theadSafeCatalog.Add(model, _emailSendler);
            return View(_theadSafeCatalog);

        }

        /// <summary> Вывести продукты </summary>  
        [HttpGet]
        public IActionResult Products()
        {
            return View(_theadSafeCatalog);
        }

        /// <summary> Добавить продукт </summary>       
        [HttpPost]
        public IActionResult Products(ThreadSafeCatalog.Product model)
        {
            _theadSafeCatalog.Add(model, _emailSendler);
            return View(_theadSafeCatalog);
        }

        /// <summary> Вывести страницу с удалением продукта </summary>
        [HttpGet]
        public IActionResult RemuvingAProduct()
        {
            return View(_theadSafeCatalog);
        }

        /// <summary> Удалить продукт </summary>
        [HttpPost]
        public IActionResult RemuvingAProduct(ThreadSafeCatalog.Product model)
        {
            _theadSafeCatalog.Remove(model);
            return View(_theadSafeCatalog);
        }
    }
}
