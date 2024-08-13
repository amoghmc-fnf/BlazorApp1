using System.ComponentModel.DataAnnotations;

namespace BlazorAppWebAssembly.DTOs
{
    public class Employee
    {
        public int EmpId { get; set; }

        [Required(ErrorMessage = "Name cannot be empty!")]
        public string EmpName { get; set; } = null!;

        [Required(ErrorMessage = "Address cannot be empty!")]
        public string EmpAddress { get; set; } = null!;

        [Required(ErrorMessage = "Salary cannot be empty!")]
        public decimal EmpSalary { get; set; }

        [Range (0, 5)]
        [Required(ErrorMessage = "Department ID cannot be empty!")]
        public int DeptId { get; set; }
    }
}
