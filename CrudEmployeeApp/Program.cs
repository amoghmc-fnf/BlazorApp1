using CrudEmployeeApp.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

namespace CrudEmployeeApp
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");

            builder.Services.AddScoped(sp => new HttpClient
            {
                BaseAddress = new Uri("http://localhost:5204/api/CrudEmployee/\"")
            });

            builder.Services.AddScoped<IEmpService, CrudEmployeeService>();

            await builder.Build().RunAsync();
        }
    }
}
