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
        private readonly IConfiguration _configuration;
       // private readonly ILogRepo _logRepo;

        public ProductRepo(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetValue<string>("ConnectionString:DefaultConn");

        }
        
       // string connString = "Server=MCNDESKTOP40; Database = Test; User ID = sa; Password = Password$2";
        public async Task<IEnumerable<Products>> GetProduct()
        {
            
            IEnumerable<Products> product = null;
            try
            {
                using(var connection = new SqlConnection(_connectionString))
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
                using (var connection = new SqlConnection(_connectionString))
                {
                    var procedure = "[AddUpdateProduct]";
                    var values = new
                    {
                        Id        = products.Id,
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

        public async Task<int> DeleteProduct(Int64 productId)
        {
            int statusid = 0;
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    var procedure = "[DeleteProduct]";
                    var values = new
                    {
                     
                        ProductId = productId
                    };

                    statusid = await connection.QueryFirstOrDefaultAsync<int>(procedure, values, commandType: CommandType.StoredProcedure);
                }

            }
            catch (Exception ex)
            {

            }
            return statusid;

        }

    }
}
