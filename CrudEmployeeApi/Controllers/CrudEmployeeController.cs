using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices.JavaScript;

namespace CrudEmployeeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("cors")]
    //api/CrudEmployee/
    public class CrudEmployeeController : ControllerBase
    {
        private EmployeeDbContext _context;
        public CrudEmployeeController(EmployeeDbContext context)
        {
            _context = context;
        }

        [HttpGet("AllEmployees")]
        public async Task<IActionResult> GetAllEmployees()
        {
            var data = await _context.Employees.ToListAsync();
            return Ok(data);
        }

        [HttpGet("AllEmployees/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var found = await _context.Employees.FirstOrDefaultAsync((e) => e.Id == id);
            if (found == null)
                return BadRequest(new { Message = "Employee not found!" });
            return Ok(found);
        }

        [HttpPost]
        public async Task<IActionResult> AddEmployee(Employee employee)
        {
            employee.Id = 0;
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();
            return Ok(new {Message = "Employee added successfully!"});
        }

        [HttpPut]
        public async Task<IActionResult> UpdateEmployee(Employee emp)
        {
            var found = await _context.Employees.FirstOrDefaultAsync((e) => e.Id == emp.Id);
            if (found != null)
            {
                found.Name = emp.Name;
                found.Address = emp.Address;
                found.Salary = emp.Salary;
                await _context.SaveChangesAsync();
                return Ok(new { Message = "Employee updated successfully!" });
            }
            else return BadRequest(new { Message = "Employee not found!" });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var found = await _context.Employees.FirstOrDefaultAsync((e) => e.Id == id);
            if (found != null)
            {
                _context.Remove(found);
                await _context.SaveChangesAsync();
                return Ok(new { Message = "Employee deleted successfully!" });
            }
            else return BadRequest(new { Message = "Employee not found!" });
        }

    }
}
