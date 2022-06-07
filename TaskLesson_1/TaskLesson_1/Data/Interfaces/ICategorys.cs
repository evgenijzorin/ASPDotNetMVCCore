using TaskLesson_1.Data.Models;

namespace TaskLesson_1.Data.Interfaces
{
    public interface ICategorys
    {
        // Получение всех категории товаров
        IEnumerable<Category> AllCategorys { get; }
    }
}
