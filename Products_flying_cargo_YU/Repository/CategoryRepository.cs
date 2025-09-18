using Products_flying_cargo_YU.Data;
using Products_flying_cargo_YU.Interface;
using Products_flying_cargo_YU.Models;

namespace Products_flying_cargo_YU.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly DataContext _context;
        public CategoryRepository(DataContext context)
        {
            _context = context;
        }

        public ICollection<Category> GetCategories()
        {
            return _context.Categories.OrderBy(p => p.CategoryID).ToList();
        }
    }
}
