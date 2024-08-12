namespace BlazorAppWebAssembly.Services
{
    public class ArithematicService : IArithematicService
    {
        private ISimpleService _service;
        private string caller;
        public ArithematicService(ISimpleService service)
        {
            this._service = service;
            this.caller = this._service.GetName();
        }
        public double AddFunction(double first, double second)
        {
            Console.WriteLine("Add function called by " + caller);
            return first + second;
        }
        public double SubFunction(double first, double second) => first - second;
        public double MultFunction(double first, double second) => first * second;
        public double DivFunction(double first, double second) => first / second;
        public double SquareFunction(double x) => x * x;
        public double SquareRootFunction(double x) => Math.Sqrt(x);
    }
}
