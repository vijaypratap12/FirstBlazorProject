using FirstBlazorApp.Shared;

namespace FirstBlazorApp.Server.DAL.Interfaces
{
    public interface ICategoryRepo
    {
        Task<IEnumerable<Category>> GetCategory();
        Task<int> AddUpdateCategory(Category category);
    }
}
