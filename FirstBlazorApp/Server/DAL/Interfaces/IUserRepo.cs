using FirstBlazorApp.Shared;

namespace FirstBlazorApp.Server.DAL.Interfaces
{
    public interface IUserRepo
    {
        Task<int> GetUserDetail(User user);
    }
}
