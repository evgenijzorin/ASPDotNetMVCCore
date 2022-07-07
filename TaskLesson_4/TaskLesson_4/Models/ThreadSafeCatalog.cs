using System.Collections.Concurrent;
using TaskLesson_4.Servicies;
using TaskLesson_4.Servicies.Interfaces;

namespace TaskLesson_4.Models
{
    public class ThreadSafeCatalog
    {
        public class Category
        {
            public Guid? Id { get; set; }
            public string Name { get; set; }
        }
        //public record Category(Guid Id, string Name);
        private readonly ConcurrentDictionary<Guid?/* Id */, Category> _categoriesDictionary = new();
        public void Add(Category category, IEmailSender _emailSendler)
        {   
            _categoriesDictionary.TryAdd(category.Id, category);
            // Отправка сообщения            
            _ = _emailSendler.SendEmailAsync("evgenijzorin@bk.ru", "asp2022gb@rodion-m.ru", "3drtLSa1", $"Оповещение о добавлениии категории {DateTime.Now}",
                                         $"Добавлена новая категория {category.Name}, id{category.Id}");
        } 
        public int CategoriesCount => _categoriesDictionary.Count;
        public void Remove(Category category) => _productsDictionary.TryRemove(category.Id, out _);
        public List<Category> Categories() => _categoriesDictionary.Values.ToList();

        // Продукты
        public record Product(Guid Id, string Name, string Description, decimal Price, string Image, Guid? CategoryId);
        private readonly ConcurrentDictionary<Guid?/* Id */, Product> _productsDictionary = new();
        public int ProductsCount => _productsDictionary.Count;
        public void Add(Product product, IEmailSender _emailSendler)
        {
            _productsDictionary.TryAdd(product.Id, product);
            _ = _emailSendler.SendEmailAsync("evgenijzorin@bk.ru", "asp2022gb@rodion-m.ru", "3drtLSa1", $"Оповещение о добавлениии продукта {DateTime.Now}",
                             $"Добавлен новый продукт {product.Name}, id{product.Id}");
        }
        public void Remove(Product product) => _productsDictionary.TryRemove(product.Id, out _);
        public List<Product> Products() => _productsDictionary.Values.ToList();
    }

}
