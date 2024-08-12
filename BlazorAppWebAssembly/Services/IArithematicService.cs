namespace BlazorAppWebAssembly.Services
{
    public interface IArithematicService
    {
        double AddFunction(double first, double second);
        double DivFunction(double first, double second);
        double MultFunction(double first, double second);
        double SquareFunction(double x);
        double SquareRootFunction(double x);
        double SubFunction(double first, double second);
    }
}