using BlazorApp1.Models;
using System.Net.Http.Json;

namespace BlazorApp1.Services
{
    public interface IProductService
    {
        Task<Product> GetProductByIdASync(int id);
        Task<List<Product>> GetProductsAsync();
    }
    public class ProductService : IProductService
    {
        private readonly HttpClient httpClient;
        public ProductService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<List<Product>> GetProductsAsync()
        {
            return await httpClient.GetFromJsonAsync<List<Product>>("AllProducts");
        }

        public async Task<Product> GetProductByIdASync(int id)
        {
            return await httpClient.GetFromJsonAsync<Product>("AllProducts/{id}");
        }

    }
}
