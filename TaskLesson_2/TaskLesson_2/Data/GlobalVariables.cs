using TaskLesson_2.Data.Interfaces;
using TaskLesson_2.Data.Mocks;
namespace TaskLesson_2.Data
{
    public static class GlobalVariables
    {
        /// <summary>
        ///  Глобальный ассортимент товаров для проверки
        /// </summary>
        public static Catalog products = new Catalog();
        // при релизе планируется заменить  new Catalog() на new Products()
        public static ICategorys categorys = new MockCategorys();
        
    }
}
