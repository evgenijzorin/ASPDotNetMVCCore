using Microsoft.AspNetCore.Mvc;
using TaskLesson_5.Models;
using TaskLesson_5.Options;
using TaskLesson_5.Servicies.Interfaces;


namespace TaskLesson_5.Controllers
{
    public class CatalogController : Controller
    {
        // Зависимости
        private readonly ILogger _logger;
        private readonly IEmailSender _emailSendler; // в _emailSendler автоматически поступают конфигурации SmtpConfig, так как была зарегистрированна зависимость
        public CatalogController(IEmailSender emailSendler, ILogger<CatalogController> logger)
        {
            _emailSendler = emailSendler ?? throw new ArgumentNullException(nameof(emailSendler)); // присвоение и валидация зависимости 
            _logger = logger;
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
            _logger.LogInformation("Добавлена категория");
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
