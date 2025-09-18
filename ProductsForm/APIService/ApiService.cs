using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ProductsForm.APIService
{
    public class ApiService
    {
        private readonly HttpClient _httpClient;

        public ApiService()
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:5001/")
            };
        }

        public async Task<List<ProductsDto>> GetProductsAsync()
        {
            var response = await _httpClient.GetAsync("api/products");
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<List<ProductsDto>>(json);
        }

        public async Task<ProductDTO> AddProductAsync(ProductDTO product)
        {
            var jsonContent = new StringContent(JsonSerializer.Serialize(product), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("api/products", jsonContent);
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<ProductDTO>(json);
        }
    }
}
