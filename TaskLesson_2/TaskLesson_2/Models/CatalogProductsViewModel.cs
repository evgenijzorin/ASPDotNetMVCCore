using TaskLesson_2.Data;
using TaskLesson_2.Data.Models;

namespace TaskLesson_2.Models
{
    public class CatalogProductsViewModel
    {
        /// <summary> Отображаемый список продуктов </summary>
        public IEnumerable<Product> products { get; set; }
        /// <summary> Отображаемая текущая категория продуктов </summary>
        public string currentCategory { get; set; }      
    }
}
