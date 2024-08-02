using BlazorApp1.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

namespace BlazorApp1
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");

            builder.Services.AddScoped(sp => new HttpClient {
                BaseAddress = new Uri("http://localhost:5141/api/Product/") 
            });

            builder.Services.AddScoped<IProductService, ProductService>();

            await builder.Build().RunAsync();
        }
    }
}
