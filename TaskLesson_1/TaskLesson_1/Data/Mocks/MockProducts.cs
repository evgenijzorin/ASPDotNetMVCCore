using TaskLesson_1.Data.Interfaces;
using TaskLesson_1.Data.Models;

namespace TaskLesson_1.Data.Mocks
{
    public class MockProducts : IAllProducts
    {
        private static readonly ICategorys _categorysProducts = new MockCategorys();

        public List<Product> _products = new List<Product>
        {
            new Product {
                Id = 1,
                Name ="Colorpeps",
                Category = _categorysProducts.AllCategorys.ElementAt(0),
                Price = 404.2m,
                Image="/img/Colorpeps.jpg"},

            new Product { Id = 1,
                Name ="Faber-Castell",
                Category=_categorysProducts.AllCategorys.ElementAt(0),            
                Price = 1650.0m,
                Image="/img/Faber-Castell.jpg"},

            new Product { Id = 1,
                Name ="gamma",
                Category=_categorysProducts.AllCategorys.ElementAt(0),
                Price = 560.22m,
                Image="/img/gamma.jpg"}
        };

        public IEnumerable<Product> Products
        {
            get
            {
                return _products;
            }
        }

        /// <summary>
        /// Добавить продукт в коллекцию продуктов
        /// </summary>
        /// <param name="product"></param>
        /// <returns>порядковый номер добавленного элемента</returns>
        public int AddProduct(Product product)
        {
            _products.Add(product);
            // Определить порядковый номер добавленного элемента              
            return _products.IndexOf(product);
        }

    }
}
