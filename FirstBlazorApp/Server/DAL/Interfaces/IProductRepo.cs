using FirstBlazorApp.Server.Model;
using FirstBlazorApp.Shared;

namespace FirstBlazorApp.Server.DAL.Interfaces
{
    public interface IProductRepo
    {
        Task<IEnumerable<Products>> GetProduct();
        Task<int> AddProduct(Products products);
    }
}
