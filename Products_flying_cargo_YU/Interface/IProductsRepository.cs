using Products_flying_cargo_YU.Models;

namespace Products_flying_cargo_YU.Interface
{
    public interface IProductsRepository
    {
        ICollection<Products> GetProducts();
        Products GetProduct(int id);
        bool ProductExists(int id);
        ICollection<Category> GetCategoryByProduct(int productId);
        bool CreateProduct(int categoryId, Products product);
        bool UpdateProduct(int categoryId, Products product);
        bool DeleteProduct(Products product);
        bool Save();
    }
}
