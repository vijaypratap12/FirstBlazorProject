using Dapper;
using FirstBlazorApp.Server.DAL.Interfaces;
using FirstBlazorApp.Server.Model;
using FirstBlazorApp.Shared;
using System.Data;
using System.Data.SqlClient;

namespace FirstBlazorApp.Server.DAL
{
    public class ProductRepo : IProductRepo
    {
        private readonly string _connectionString;
        private readonly IConfiguration _config;
       // private readonly ILogRepo _logRepo;

        public ProductRepo(IConfiguration configuration)
        {
            _config = configuration;
            _connectionString = _config.GetConnectionString("DefaultConn");
        }
        public async Task<IEnumerable<Products>> GetProduct()
        {
            IEnumerable<Products> product = null;
            try
            {
                using(var connection = new SqlConnection("Server=DESKTOP-UPVU5MD\\SQLEXPRESS; Database = test; User ID = sa; Password = Vijay@123"))
                {
                    var procedure = "[GetProductDetails]";
                   
                     product = await connection.QueryAsync<Products>(procedure, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {

            }
            
            return product;
        }

        public async Task<int> AddProduct(Products products)
        {
            int statusid = 0;
            try
            {
                using (var connection = new SqlConnection("Server=DESKTOP-UPVU5MD\\SQLEXPRESS; Database = test; User ID = sa; Password = Vijay@123"))
                {
                    var procedure = "[AddProduct]";
                    var values = new
                    {
                        ProductId = products.ProductId,
                        ProductName = products.ProductName,
                        Description = products.Description
                    };

                    statusid = await connection.QueryFirstOrDefaultAsync<int>(procedure, values, commandType: CommandType.StoredProcedure);
                }

            }
            catch(Exception ex)
            {

            }
            return statusid;
        }

    }
}
