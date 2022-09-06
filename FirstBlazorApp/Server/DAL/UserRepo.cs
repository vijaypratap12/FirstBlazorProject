using Dapper;
using FirstBlazorApp.Server.DAL.Interfaces;
using FirstBlazorApp.Shared;
using System.Data;
using System.Data.SqlClient;

namespace FirstBlazorApp.Server.DAL
{
    public class UserRepo:IUserRepo
    {
        private readonly string _connectionString;
        private readonly IConfiguration _configuartion;
        public UserRepo(IConfiguration configuration)
        {
            _configuartion = configuration;
            _connectionString = _configuartion.GetValue<string>("ConnectionString:DefaultConn");
        }
 
        public async Task<IEnumerable<User>> GetUserDetail(User user)
        {
            IEnumerable<User> users = null; 
            var procedure = "[GetUserDetail]";
            using(var connection = new SqlConnection(_connectionString))
            {
                users = await connection.QueryAsync<User>(procedure, commandType: CommandType.StoredProcedure);
            }
            return users;

        }
    }
}
