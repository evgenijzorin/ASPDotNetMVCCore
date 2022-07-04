using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskLesson_1.Data;
using TaskLesson_1.Data.Models;
using TaskLesson_1.ViewModels;

namespace TaskLesson_1.Controllers
{
    public class AddNewProductController : Controller
    {
        // GET: AddNewProductController
        public ViewResult Index()
        {
            // Передаем данные в класс для отображения
            CatalogProductsViewModel obj = new CatalogProductsViewModel();
            obj.allProducts = MyGlobalVariables.globalMockProducts._products;
            obj.currentCategory = "Канцелярские принадлежности";
            return View(obj);
        }

        public ActionResult Add(string name, string description, decimal price, string image)
        {
            Product product = new Product {Name = name,Description= description,Price=price, Image = image};
            MyGlobalVariables.globalMockProducts.AddProduct(product);
            // Передаем данные в класс для отображения
            CatalogProductsViewModel obj = new CatalogProductsViewModel();
            obj.allProducts = MyGlobalVariables.globalMockProducts._products;
            obj.currentCategory = "Канцелярские принадлежности";
            return View(obj);
        }

    }
}
