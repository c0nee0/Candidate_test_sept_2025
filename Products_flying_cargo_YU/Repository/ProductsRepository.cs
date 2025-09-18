using Microsoft.EntityFrameworkCore;
using Products_flying_cargo_YU.Data;
using Products_flying_cargo_YU.Dto;
using Products_flying_cargo_YU.Interface;
using Products_flying_cargo_YU.Models;

namespace Products_flying_cargo_YU.Repository
{
    public class ProductsRepository : IProductsRepository
    {
        private readonly DataContext _context;
        public ProductsRepository(DataContext context)
        {
            _context = context;
        }

        public ICollection<Products> GetProducts()
        {
            return _context.Products
                .Include(p => p.ProductCategories)
                    .ThenInclude(pc => pc.Category)
                .OrderBy(p => p.ProductID)
                .ToList();
        }

        public Products GetProduct(int id)
        {
            return _context.Products.Where(p => p.ProductID == id).FirstOrDefault();
        }

        bool IProductsRepository.ProductExists(int id)
        {
            return _context.Products.Any(p => p.ProductID == id);
        }

        public ICollection<Category> GetCategoryByProduct(int productId)
        {
            return _context.ProductCategories.Where(e => e.ProductID == productId).Select(c => c.Category).ToList();
        }

        public bool CreateProduct(int categoryId, Products product)
        {
            var productCategoryEntity = _context.Categories.Where(a => a.CategoryID == categoryId).FirstOrDefault();

            _context.Add(product);

            var productCategory = new ProductCategory()
            {
                Category = productCategoryEntity,
                Product = product
            };

            _context.Add(productCategory);

            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateProduct(int categoryId, Products product)
        {
            var newCategory = _context.Categories
                    .FirstOrDefault(c => c.CategoryID == categoryId);

            if (newCategory == null)
            {
                throw new ArgumentException($"Category with ID {categoryId} does not exist.");
            }

            _context.Products.Update(product);

            var existingProductCategory = _context.ProductCategories
                .FirstOrDefault(pc => pc.ProductID == product.ProductID);

            if (existingProductCategory != null)
            {
                existingProductCategory.CategoryID = categoryId;
                _context.ProductCategories.Update(existingProductCategory);
            }
            else
            {
                var newProductCategory = new ProductCategory
                {
                    ProductID = product.ProductID,
                    CategoryID = categoryId
                };
                _context.ProductCategories.Add(newProductCategory);
            }

            return Save();
        }

        public bool DeleteProduct(Products product)
        {
            var productCategories = _context.ProductCategories
                   .Where(pc => pc.ProductID == product.ProductID)
                   .ToList();

            _context.ProductCategories.RemoveRange(productCategories);

            _context.Products.Remove(product);

            return Save();
        }
    }
}
