using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsForm.Models
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
