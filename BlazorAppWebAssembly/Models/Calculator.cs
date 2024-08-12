using System.ComponentModel.DataAnnotations;

namespace BlazorAppWebAssembly.Models
{
    public class Calculator
    {
        public enum Options
        {
            Add, Subtract, Multiply, Divide, Square, SquareRoot
        }

        [Required(ErrorMessage = "First value must be set")]
        public double FirstValue {  get; set; }
        [Required(ErrorMessage = "Second value must be set")]
        public double SecondValue { get; set; }
        public string Option { get; set; }
    }
}
