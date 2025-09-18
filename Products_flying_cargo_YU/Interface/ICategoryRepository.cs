using Products_flying_cargo_YU.Models;

namespace Products_flying_cargo_YU.Interface
{
    public interface ICategoryRepository
    {
        ICollection<Category> GetCategories();
    }
}
