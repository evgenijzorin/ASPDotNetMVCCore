using TaskLesson_2.Data.Interfaces;
using TaskLesson_2.Data.Models;
using TaskLesson_2.Data.Mocks;
using System.Collections.Concurrent;

namespace TaskLesson_2.Data.Mocks
{
    public class Catalog
    {
        /// <summary> Категории для проверки </summary>
        private static ICategorys _mockCategorys = new MockCategorys();

        /// <summary> Список предоставляемых товаров </summary>          
        private ConcurrentDictionary<int, Product> _products =
            new ConcurrentDictionary<int, Product>(
                new Dictionary<int, Product>()
                {
                    {1, new Product {Id = 1, Name ="Desert Eagle", Description="cамозарядный пистолет крупного калибра.",Image="/img/Desert Eagle.jpg",
                        Category=_mockCategorys.AllCategorys.ElementAt(0) }},

                    {2, new Product { Id = 2, Name ="Glock 17", Description="популярный австрийский пистолет.", Image="/img/Glock 17.jpg",
                        Category=_mockCategorys.AllCategorys.ElementAt(0)}},
                    {3, new Product {Id = 3, Name = "Colt Python", Description = "шестизарядный револьвер калибра .357 Magnum.",Image = "/img/Colt Python.jpg",
                        Category = _mockCategorys.AllCategorys.ElementAt(0)
                    }},
                    {4, new Product {Id = 4, Name = "АК74-М", Description = "автомат Калашникова образца 1974 года.", Image = "/img/АК74-М.jpg",
                        Category = _mockCategorys.AllCategorys.ElementAt(1)
                    }},
                    {5, new Product { Id = 5, Name = "АР-15",  Description = "американская полуавтоматическая винтовка под патрон 5,56×45 мм.", Image = "/img/АР-15.jpg",
                        Category = _mockCategorys.AllCategorys.ElementAt(1)
                    }}
                });

        /// <summary> Вывести весь список товаров </summary>
        public ConcurrentDictionary<int, Product> AllProducts
        {
            get { return _products; }
        }
        /// <summary>
        /// Добавить новый продукт в список товаров
        /// </summary>
        /// <param name="product"> добавляемый товар </param>
        /// <returns>порядковый номер добавленного элемента</returns>
        public int AddProduct(Product product)
        {
            // Определить Id предшествующего элемента и присвоить Id новому элементу
            int id = _products.Last().Key;
            id++;
            product.Id = id;
            // Добавить новый продукт
            _products.TryAdd(id, product);
                
            // Определить порядковый номер добавленного элемента              
            return id;
        }
    }
}
