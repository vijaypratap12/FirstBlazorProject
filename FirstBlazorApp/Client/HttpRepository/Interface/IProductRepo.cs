using FirstBlazorApp.Server.Model;

namespace FirstBlazorApp.Client.HttpRepository.Interface
{
    public interface IProductRepo
    {
            Task<List<Products>> GetProducts();

    }
}
