namespace BlazorAppWebAssembly.Services
{
    public static class RegisterServices
    {
        public static void Register(IServiceCollection services, IConfiguration config)
        {
            string baseAddress = config["MySettings:baseUrl"];
            services.AddScoped<ISimpleService, SimpleService>();
            services.AddScoped<IArithematicService, ArithematicService>();
            services.AddScoped<IEmpHttpService, EmpHttpService>();
            services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(baseAddress) });
        }
    }
}
