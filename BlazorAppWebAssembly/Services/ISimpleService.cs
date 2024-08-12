namespace BlazorAppWebAssembly.Services
{
    public interface ISimpleService
    {
        string GetName();
    }

    public class SimpleService : ISimpleService
    {
        private readonly IConfiguration _config;
        public SimpleService(IConfiguration config)
        {
            this._config = config;
        }
        public string GetName()
        {
            // 2 ways to access appsettings
            return _config.GetSection("MySettings:name").Value;
            //return _config["MySettings:name"];
        }
    }
}