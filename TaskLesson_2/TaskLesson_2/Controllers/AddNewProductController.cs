using Microsoft.AspNetCore.Mvc;
using TaskLesson_2.Data;
using TaskLesson_2.Data.Models;
using TaskLesson_2.Models;



namespace TaskLesson_2.Controllers
{
    public class AddNewProductController : Controller
    {
        public ViewResult Index ()
        {
            // подготовить видовую модель
            CatalogProductsViewModel catalogProductsViewModel = new CatalogProductsViewModel();
            catalogProductsViewModel.currentCategory = GlobalVariables.categorys.AllCategorys.ElementAt(3).Name; // вывести категорию "Весь ассортимент оружия"
            catalogProductsViewModel.products = GlobalVariables.products.AllProducts.Values;
            return View(catalogProductsViewModel);
        }

        public ActionResult Add(string name, string description, string image, decimal price)
        {
            Product product = new Product() { Name = name, Description = description, Price = price, Image = image };
            GlobalVariables.products.AddProduct(product);
            // вызвать вид другого контроллера
            return RedirectToAction("Index", "AddNewProduct");             
        }
    }
}
