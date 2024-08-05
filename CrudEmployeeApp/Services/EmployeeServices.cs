using CrudEmployeeApp.Models;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
namespace CrudEmployeeApp.Services
{
    public interface IEmpService
    {
        Task<List<Employee>> GetAll();
        Task<List<Employee>> GetByName(string name);
        Task<Employee> GetById(int id);
        Task<HttpResponseMessage> AddEmployee(Employee employee);
        Task<HttpResponseMessage> DeleteEmployee(int id);
        Task<HttpResponseMessage> UpdateEmployee(Employee employee);
    }

    public class CrudEmployeeService : IEmpService
    {
        private HttpClient httpClient;
        public CrudEmployeeService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        public async Task<HttpResponseMessage> AddEmployee(Employee employee)
        {
            var json = JsonSerializer.Serialize(employee);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            return await httpClient.PostAsync("", content);
        }

        public Task<HttpResponseMessage> DeleteEmployee(int id)
        {
            return httpClient.DeleteAsync($"{id}");
        }

        public async Task<List<Employee>> GetAll()
        {
            return await httpClient.GetFromJsonAsync<List<Employee>>("AllEmployees");
        }

        public async Task<Employee> GetById(int id)
        {
            var content = await httpClient.GetAsync($"AllEmployees/{id}");
            var data = await content.Content.ReadFromJsonAsync<Employee>();
            return data;
        }

        public async Task<List<Employee>> GetByName(string name)
        {
            var content = await this.GetAll();
            var data = content.FindAll(e => e.Name == name);
            return data;
        }

        public Task<HttpResponseMessage> UpdateEmployee(Employee employee)
        {
            return httpClient.PutAsJsonAsync<Employee>("", employee);
        }
    }
}
