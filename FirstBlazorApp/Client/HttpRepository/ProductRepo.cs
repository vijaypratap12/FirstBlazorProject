using FirstBlazorApp.Client.HttpRepository.Interface;
using FirstBlazorApp.Server.Model;
using System.Text.Json;

namespace FirstBlazorApp.Client.HttpRepository
{
        public class ProductRepo : IProductRepo
        {
            private readonly HttpClient _client;
            private readonly JsonSerializerOptions _options;

            public ProductRepo(HttpClient client)
            {
                _client = client;
                _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            }

            public async Task<List<Products>> GetProducts()
            {
                var response = await _client.GetAsync("getproducts");
                var content = await response.Content.ReadAsStringAsync();
                if (!response.IsSuccessStatusCode)
                {
                    throw new ApplicationException(content);
                }

                var products = JsonSerializer.Deserialize<List<Products>>(content, _options);
                return products;
            }
        }
}
