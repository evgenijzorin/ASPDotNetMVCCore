using Microsoft.AspNetCore.Mvc;
using TaskLesson_2.Models;
using TaskLesson_2.Data;

namespace TaskLesson_2.Controllers
{
    public class CatalogController : Controller
    {
        public ViewResult Products() 
        { 
            // подготовить видовую модель
            CatalogProductsViewModel catalogProductsViewModel = new CatalogProductsViewModel();
            catalogProductsViewModel.currentCategory = GlobalVariables.categorys.AllCategorys.ElementAt(3).Name; // вывести категорию "Весь ассортимент оружия"
            catalogProductsViewModel.products = GlobalVariables.products.AllProducts.Values;
            return View(catalogProductsViewModel);
        }                 
    }
}
