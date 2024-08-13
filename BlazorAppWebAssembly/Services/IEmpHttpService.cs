using BlazorAppWebAssembly.DTOs;
using System.Net.Http.Json;

namespace BlazorAppWebAssembly.Services
{
    public interface IEmpHttpService
    {
        Task<List<Employee>> GetAll();
        Task<Employee> GetById(int id);
        Task DeleteById(int id);
        Task Update(Employee employee);
        Task Add(Employee employee);
    }

    public class EmpHttpService : IEmpHttpService
    {
        private HttpClient _httpClient;
        public EmpHttpService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task Add(Employee employee)
        {
            await _httpClient.PostAsJsonAsync<Employee>("Employee", employee);
        }

        public async Task DeleteById(int id)
        {
            await _httpClient.DeleteAsync($"Employee\\/{id}");
        }

        public async Task<List<Employee>> GetAll()
        {
            return await _httpClient.GetFromJsonAsync<List<Employee>>("Employee/AllEmployees");
        }

        public async Task<Employee> GetById(int id)
        {
            return await _httpClient.GetFromJsonAsync<Employee>($"Employee/{id}");
        }

        public async Task Update(Employee employee)
        {
            await _httpClient.PutAsJsonAsync<Employee>("Employee", employee);
        }
    }
}
