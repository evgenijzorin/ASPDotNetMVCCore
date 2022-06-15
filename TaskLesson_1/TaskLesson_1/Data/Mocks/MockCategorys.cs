
using TaskLesson_1.Data.Interfaces;
using TaskLesson_1.Data.Models;

namespace TaskLesson_1.Data.Mocks

{
    internal class MockCategorys : ICategorys
    {
        public IEnumerable<Category> AllCategorys
        {
            get
            {
                return new List<Category>
                {                          
                    new Category { CategoryName = "Карандаши цветные", CategoryDescription = "Различные карандаши"},
                    new Category { CategoryName = "Шариковые ручки", CategoryDescription = "Различные шариковые ручки"},                                           
                    new Category { CategoryName = "Фломастеры", CategoryDescription = "Различные фломастеры"}
                };                  
            }
        }     
    }
}