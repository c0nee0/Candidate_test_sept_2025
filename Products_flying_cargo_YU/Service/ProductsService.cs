using AutoMapper;
using Products_flying_cargo_YU.Interface;
using Products_flying_cargo_YU.Models;

namespace Products_flying_cargo_YU.Service
{
    public class ProductsService
    {
        private readonly IProductsRepository _productsRepository;
        public ProductsService(IProductsRepository productsRepository)
        {
            _productsRepository = productsRepository;
        }

        public IEnumerable<Products> GetProducts()
        {
            return _productsRepository.GetProducts();
        }

        public Products GetProduct(int productId)
        {
            return _productsRepository.GetProduct(productId);
        }

        public IEnumerable<Category> GetCategoryByProduct(int productId)
        {
            return _productsRepository.GetCategoryByProduct(productId);
        }

        public bool ProductExists(int productId)
        {
            return _productsRepository.ProductExists(productId);
        }

        public bool ProductNameExists(string productName)
        {
            return _productsRepository.GetProducts()
                .Any(p => p.ProductName.Trim().ToUpper() == productName.Trim().ToUpper());
        }

        public void CreateProduct(int categoryId, Products product)
        {
            if (ProductNameExists(product.ProductName))
                throw new Exception("Product already exists");

            if (!_productsRepository.CreateProduct(categoryId, product))
                throw new Exception("Something went wrong while saving the product");
        }

        public void UpdateProduct(int categoryId, Products product)
        {
            if (!_productsRepository.ProductExists(product.ProductID))
                throw new Exception("Product not found");

            if (!_productsRepository.UpdateProduct(categoryId, product))
                throw new Exception("Something went wrong while updating the product");
        }

        public void DeleteProduct(int productId)
        {
            var product = _productsRepository.GetProduct(productId);
            if (product == null)
                throw new Exception("Product not found");

            if (!_productsRepository.DeleteProduct(product))
                throw new Exception("Something went wrong while deleting the product");
        }
    }
}
