namespace CrudEmployeeApp.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public double Salary { get; set; }
    }

    public static class EmployeeRepo
    {
        private static List<Employee> employees = new List<Employee>
        {
            new Employee { Id = 1, Name = "Robert", Address = "Florida", Salary = 65000},
            new Employee { Id = 2, Name = "Adam", Address = "Washington", Salary = 60000},
            new Employee { Id = 3, Name = "Phaniraj", Address = "Bangalore", Salary = 70000},
            new Employee { Id = 4, Name = "Vinod", Address = "Mysore", Salary = 85000},
        };
        public static List<Employee> GetAll() => employees;

        public static void AddEmployee(Employee employee) => employees.Add(employee);
        public static Employee GetById(int id)
        {
            var found = employees.FirstOrDefault(e => e.Id == id);
            if (found != null) return found;
            else throw new NullReferenceException("Employee not found!");
        }
        public static void UpdateEmployee(Employee employee)
        {
            var found = employees.FirstOrDefault(e => e.Id == employee.Id);
            if (found != null)
            {
                found.Name = employee.Name;
                found.Address = employee.Address;
                found.Salary = employee.Salary;
            }
            else throw new NullReferenceException("Employee not found!");
        }
        public static void DeleteEmployee(int id)
        {
            var found = employees.FirstOrDefault(e => e.Id == id);
            if (found != null)
            {
                employees.Remove(found);
            }
            else throw new NullReferenceException("Employee not found!");
        }
    }
}
