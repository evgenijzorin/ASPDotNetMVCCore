using TaskLesson_2.Data.Models;

namespace TaskLesson_2.Data.Interfaces
{
    public interface ICategorys
    {
        /// <summary>
        /// Получение всех категорий товаров
        /// </summary>
        IEnumerable<Category> AllCategorys {get;}
    }
}
