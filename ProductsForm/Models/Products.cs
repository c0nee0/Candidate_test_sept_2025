using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsForm.Models
{
    public class Products
    {
        [Key]
        public int ProductID { get; set; }
        public string? ProductName { get; set; }
        public decimal Price { get; set; }
        public string? Description { get; set; }
        public int StockQuantity { get; set; }
        public DateTime CreatedAt { get; set; }

        public ICollection<ProductCategory> ProductCategories { get; set; }
    }
}
