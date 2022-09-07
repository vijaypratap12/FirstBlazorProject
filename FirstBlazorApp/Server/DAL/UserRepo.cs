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
 
        public async Task<int> GetUserDetail(User user)
        {
            int statusId = 0;
            //IEnumerable<User> users = null; 
            var procedure = "[GetUserDetail]";
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@UserName", user.UserName, DbType.String, direction: ParameterDirection.Input);
                parameters.Add("@Password", user.Password, DbType.String, direction: ParameterDirection.Input);
                parameters.Add("@StatusId", statusId, DbType.Int32, direction: ParameterDirection.Output);
                using (var connection = new SqlConnection(_connectionString))
                {
                    statusId = await connection.QueryFirstOrDefaultAsync<int>(procedure, parameters, commandType: CommandType.StoredProcedure);
                    statusId = parameters.Get<int>("@StatusId");

                }
            }
            catch(Exception ex)
            {
                throw new Exception();
            }
           
            return statusId;

        }
    }
}
