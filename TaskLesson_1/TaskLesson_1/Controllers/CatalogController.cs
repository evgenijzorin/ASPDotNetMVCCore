using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskLesson_1.Data.Interfaces;
using TaskLesson_1.ViewModels;
using TaskLesson_1.Data;

namespace TaskLesson_1.Controllers
{
    public class CatalogController : Controller
    {
        //// Переменные на интерфейсы
        //private readonly IAllProducts _allProducts;
        //private readonly ICategorys _categorys;

        //public CatalogController (IAllProducts iAllProducts, ICategorys iCategorys)
        //{
        //    _allProducts = iAllProducts;
        //    _categorys = iCategorys;
        //}

        public ViewResult products()
        {
            // Передаем данные в класс для отображения
            CatalogProductsViewModel obj = new CatalogProductsViewModel();
            obj.allProducts = MyGlobalVariables.globalMockProducts._products;
            obj.currentCategory = "Канцелярские принадлежности";
            return View(obj);
        }               
    }
}
