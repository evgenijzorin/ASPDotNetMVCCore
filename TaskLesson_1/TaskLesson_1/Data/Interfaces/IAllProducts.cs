using TaskLesson_1.Data.Models;

namespace TaskLesson_1.Data.Interfaces
{
    public interface IAllProducts
    {
        IEnumerable<Product> Products { get; } // перечисление товаров
        // Product GetProduct(int ProductId);     // Возвратить товар по ID
    }
}
