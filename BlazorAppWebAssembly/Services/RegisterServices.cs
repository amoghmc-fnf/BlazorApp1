namespace BlazorAppWebAssembly.Services
{
    public static class RegisterServices
    {
        public static void Register(IServiceCollection services)
        {
            string baseAddress = "";
            services.AddScoped<IArithematicService, ArithematicService>(options =>
            {
                return new ArithematicService("Amogh");
            });
            services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(baseAddress) });
        }
    }
}
