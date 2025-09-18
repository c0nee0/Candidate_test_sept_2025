using Products_flying_cargo_YU.Models;

namespace Products_flying_cargo_YU.Dto
{
    public class ProductsDto
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public int StockQuantity { get; set; }
        public DateTime CreatedAt { get; set; }
        public int? CategoryID { get; set; }
        public string? CategoryName { get; set; }
    }
}
