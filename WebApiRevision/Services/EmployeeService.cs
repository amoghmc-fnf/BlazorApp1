using Microsoft.AspNetCore.Mvc;
using WebApiRevision.Data;
using WebApiRevision.DTOs;

namespace WebApiRevision.Services
{
    public interface IEmployeeService
    {
        Task AddEmployee(Employee emp);
        Task DeleteEmployee(int empId);
        Task<Employee> GetEmployeeById(int empId);
        Task<List<Employee>> GetEmployees();
        Task UpdateEmployee(Employee emp);
    }

    public class EmployeeService : IEmployeeService
    {
        private readonly FnfTrainingContext _context;
        public EmployeeService(FnfTrainingContext context)
        {
            _context = context;
        }

        public async Task<Employee> GetEmployeeById(int empId)
        {
            var found = await _context.EmpTables.FindAsync(empId);
            if (found is null)
                throw new NullReferenceException($"Employee with ID: {empId} not found!");
            Employee emp = new Employee
            {
                EmpId = found.EmpId,
                EmpName = found.EmpName,
                EmpAddress = found.EmpAddress,
                EmpSalary = found.EmpSalary,
                DeptId = found.DeptId == null ? default(int) : found.DeptId.Value

                // above DeptId assignment is sytactic sugar for below code

                //if (found.DeptId == null)
                //    emp.DeptId = default(int);
                //else
                //    emp.DeptId = found.DeptId.Value;
            };
            return emp;
        }

        public async Task<List<Employee>> GetEmployees()
        {
            List<Employee> employees = new List<Employee>();
            await foreach (EmpTable empTable in _context.EmpTables)
            {
                Employee emp = new Employee
                {
                    EmpId = empTable.EmpId,
                    EmpName = empTable.EmpName,
                    EmpAddress = empTable.EmpAddress,
                    EmpSalary = empTable.EmpSalary,
                    DeptId = empTable.DeptId == null ? default(int) : empTable.DeptId.Value
                };
                employees.Add(emp);
            }
            return employees;
        }

        public async Task AddEmployee(Employee emp)
        {
            EmpTable empTable = new EmpTable();
            empTable.EmpName = emp.EmpName;
            empTable.EmpAddress = emp.EmpAddress;
            empTable.EmpSalary = emp.EmpSalary;
            empTable.DeptId = emp.DeptId == 0 ? null : emp.DeptId;
            await _context.EmpTables.AddAsync(empTable);
            await _context.SaveChangesAsync();
            return;
        }

        public async Task UpdateEmployee(Employee emp)
        {
            var found = _context.EmpTables.FirstOrDefault(e => e.EmpId == emp.EmpId);
            if (found == null)
            {
                throw new NullReferenceException($"Employee with ID: {emp.EmpId} not found to update!");

            }

            found.EmpAddress = emp.EmpAddress;
            found.EmpName = emp.EmpName;
            found.EmpAddress = emp.EmpAddress;
            found.EmpSalary = emp.EmpSalary;
            found.DeptId = emp.DeptId == 0 ? null : emp.DeptId;
            await _context.SaveChangesAsync();
            return;
        }

        public async Task DeleteEmployee(int empId)
        {
            var found = _context.EmpTables.FirstOrDefault(e => e.EmpId == empId);
            if (found == null)
            {
                throw new NullReferenceException($"Employee with ID: {empId} not found to delete!");
            }
            _context.EmpTables.Remove(found);
            await _context.SaveChangesAsync();
        }
    }
}
