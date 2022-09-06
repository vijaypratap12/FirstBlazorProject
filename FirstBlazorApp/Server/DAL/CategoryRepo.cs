using Dapper;
using FirstBlazorApp.Server.DAL.Interfaces;
using FirstBlazorApp.Shared;
using System.Data;
using System.Data.SqlClient;

namespace FirstBlazorApp.Server.DAL
{
    public class CategoryRepo:ICategoryRepo
    {
        string connString = "Server=MCNDESKTOP40; Database = Test; User ID = sa; Password = Password$2";

        public async Task<IEnumerable<Category>> GetCategory()
        {
            IEnumerable<Category> category = null;
            try
            {
                var procedure = "[GetCategories]";
                using(var connection = new SqlConnection(connString))
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

                using (var connection = new SqlConnection(connString))
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
