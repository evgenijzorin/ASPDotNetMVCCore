using TaskLesson_2.Data.Interfaces;
using TaskLesson_2.Data.Models;

namespace TaskLesson_2.Data.Mocks

{
    public class MockCategorys : ICategorys
    {
        /// <summary>
        /// категории товаров для проверки
        /// </summary>
        public IEnumerable<Category> AllCategorys
        {
            get
            {
                return new List<Category>
                {
                    new Category { Name ="Пистолеты",Description="Ассортимент короткоствольного оружья"},
                    new Category { Name ="Винтовки",Description="Ассортимент длинноствольного, нарезного оружья"},
                    new Category { Name = "Ружья", Description = "Ассортимент длинноствольного, гладкоствольного оружья" },
                    new Category { Name = "Все оружье", Description = "Весь ассортимент оружья" }
                };
            }
        }
    }
}
