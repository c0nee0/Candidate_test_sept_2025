using Products_flying_cargo_YU.Dto;
using Products_flying_cargo_YU.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ProductsWForm.Service
{
    public class ApiService
    {
        private readonly HttpClient _httpClient;

        public ApiService()
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri("http://localhost:5152/") 
            };
        }

        public async Task<List<ProductsDto>> GetProductsAsync()
        {
            var response = await _httpClient.GetAsync("api/Products");
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<List<ProductsDto>>(json, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
        }

        public async Task<List<CategoryDto>> GetCategoriesAsync()
        {
            var response = await _httpClient.GetAsync("api/Category");
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<List<CategoryDto>>(json, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
        }

        public async Task AddProductAsync(int categoryId, ProductsDto product)
        {
            var jsonContent = new StringContent(JsonSerializer.Serialize(product), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync($"api/Products?categoryId={categoryId}", jsonContent);
            response.EnsureSuccessStatusCode();
        }

        public async Task UpdateProductAsync(int productId, ProductsDto updatedProduct, int categoryId)
        {
            var jsonContent = new StringContent(
                JsonSerializer.Serialize(updatedProduct),
                Encoding.UTF8,
                "application/json"
            );

            var response = await _httpClient.PutAsync(
                    $"api/Products/{productId}?categoryId={categoryId}",
                    jsonContent
                );
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteProductAsync(int productId)
        {
            var response = await _httpClient.DeleteAsync($"api/Products/{productId}");
            response.EnsureSuccessStatusCode();
        }

    }
}
