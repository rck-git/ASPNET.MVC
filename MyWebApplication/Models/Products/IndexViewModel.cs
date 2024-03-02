namespace MyWebApplication.Models.Products
{
    public class IndexViewModel
    {
        public List<Product> ProductList { get; set; } = new List<Product>();
    }

    public class Product
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Category { get; set; }
        public string? Author { get; set; }
        public decimal? Price { get; set; }
        public string? Likes { get; set; }
        public string? Duration { get; set; }
        public bool? IsOnSale { get; set; }
    }
}
