namespace Products_flying_cargo_YU.Models
{
    public class ProductCategory
    {
        public int ProductCategoryID { get; set; }

        public int ProductID { get; set; }
        public int CategoryID { get; set; }

        public Products? Product { get; set; }
        public Category? Category { get; set; }
    }
}
