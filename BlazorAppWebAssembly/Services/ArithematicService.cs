namespace BlazorAppWebAssembly.Services
{
    public class ArithematicService : IArithematicService
    {
        private string _name;
        public ArithematicService(string name)
        {
            _name = name;
        }
        public double AddFunction(double first, double second)
        {
            Console.WriteLine("Add function called by " + _name);
            return first + second;
        }
        public double SubFunction(double first, double second) => first - second;
        public double MultFunction(double first, double second) => first * second;
        public double DivFunction(double first, double second) => first / second;
        public double SquareFunction(double x) => x * x;
        public double SquareRootFunction(double x) => Math.Sqrt(x);
    }
}
