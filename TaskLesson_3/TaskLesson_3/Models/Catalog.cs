using System.Collections.Concurrent;

namespace TaskLesson_3.Models
{
    public class TheadSafeCatalog
    {
        // Категории
        public class Category
        {
            public Guid? Id { get; set; }
            public string Name { get; set; }
        }
        //public record Category(Guid Id, string Name);
        private readonly ConcurrentDictionary<Guid?/* Id */, Category> _categoriesDictionary = new();
        public void Add(Category category) => _categoriesDictionary.TryAdd(category.Id, category);
        public int CategoriesCount => _categoriesDictionary.Count;
        public void Remove(Category category) => _productsDictionary.TryRemove(category.Id, out _);
        public List<Category> Categories() => _categoriesDictionary.Values.ToList();

        // Продукты
        public record Product(Guid Id, string Name, string Description, decimal Price, string Image, Guid? CategoryId);
        private readonly ConcurrentDictionary<Guid?/* Id */, Product> _productsDictionary = new();
        public int ProductsCount => _productsDictionary.Count;
        public void Add(Product product) => _productsDictionary.TryAdd(product.Id, product);
        public void Remove(Product product) => _productsDictionary.TryRemove(product.Id, out _);
        public List<Product> Products() => _productsDictionary.Values.ToList();
    }

}
