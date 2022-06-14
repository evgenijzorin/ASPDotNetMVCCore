namespace TaskLesson_3.Models
{
    public class Catalog
    {                   
        private List<Category> _categories { get; set; } = new();
        private List<Product> _products { get; set; } = new();
        /// <summary>  Получить все товары </summary>
        public List<Product> Products { get { return _products; } }
        /// <summary>  Получить все категории </summary>
        public List<Category> Categories { get { return _categories; } }

    }

    public class Category
    {
        public int Id { get; set; }          
        public string Name { get; set; }          
    }
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public string? Image { get; set; }
        public int CategoryId { get; set; }
    }
    
}
