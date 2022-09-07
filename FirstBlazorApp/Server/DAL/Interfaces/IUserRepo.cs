using FirstBlazorApp.Shared;

namespace FirstBlazorApp.Server.DAL.Interfaces
{
    public interface IUserRepo
    {
        Task<IEnumerable<User>> GetUserDetail(User user);
    }
}
