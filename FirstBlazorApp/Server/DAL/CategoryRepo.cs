using Dapper;
using FirstBlazorApp.Server.DAL.Interfaces;
using FirstBlazorApp.Shared;
using System.Data;
using System.Data.SqlClient;

namespace FirstBlazorApp.Server.DAL
{
    public class CategoryRepo:ICategoryRepo
    {
        private readonly string _connectionString;
        private readonly IConfiguration _configuration;
        public CategoryRepo(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetValue<string>("ConnectionString:DefaultConn");
        }
       

        public async Task<IEnumerable<Category>> GetCategory()
        {
            IEnumerable<Category> category = null;
            try
            {
                var procedure = "[GetCategories]";
                using(var connection = new SqlConnection(_connectionString))
                {
                    category = await connection.QueryAsync<Category>(procedure, commandType: CommandType.StoredProcedure);
                }

            }
            catch(Exception ex)
            {

            }
            return category;
        }
        public async Task<int> AddUpdateCategory(Category category)
        {
            
            int statusId = 0;
            try
            {
                var procedure = "[AddUpdateCategory]";
                var parameter = new DynamicParameters();
                parameter.Add("@Id", category.Id, DbType.Int64, direction: ParameterDirection.Input);
                parameter.Add("@CategoryId", category.CategoryId, DbType.Int64, direction: ParameterDirection.Input);
                parameter.Add("@categoryName", category.CategoryName, DbType.String, direction: ParameterDirection.Input);
                parameter.Add("@Description", category.Description, DbType.String, direction: ParameterDirection.Input);
                parameter.Add("@StatusId", statusId, DbType.Int32, direction: ParameterDirection.Output);

                using (var connection = new SqlConnection(_connectionString))
                {
                  
                    statusId = await connection.QueryFirstOrDefaultAsync<int>(procedure, parameter, commandType: CommandType.StoredProcedure);
                    statusId = parameter.Get<int>("@StatusId");
                }
            }
            catch(Exception ex)
            {

            }
            return statusId;
        }
    }
}
