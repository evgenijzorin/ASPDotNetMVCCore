using TaskLesson_1.Data.Models;
using TaskLesson_1.Data.Interfaces;

namespace TaskLesson_1.ViewModels
{
    public class CatalogProductsViewModel
    {
        public IEnumerable<Product> allProducts { get; set; }
        public string currentCategory { get; set; }
    }
}
