using TaskLesson_2.Data.Models;

namespace TaskLesson_2.Data.Interfaces
{
    public interface IProducts
    {
        /// <summary>
        /// Получение всех продуктов
        /// </summary>
        IEnumerable<Product> AllProducts { get; }
    }
}
