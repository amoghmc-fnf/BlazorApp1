using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiRevision.DTOs;
using WebApiRevision.Services;

namespace WebApiRevision.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("cors")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService service;

        public EmployeeController(IEmployeeService service)
        {
            this.service = service;
        }

        [HttpGet("AllEmployees")]
        public async Task<ActionResult<List<Employee>>> GetAll()
        {
            return await service.GetEmployees();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Find(int id)
        {
            try
            {
                var found = await service.GetEmployeeById(id);
                return Ok(found);
            }
            catch (NullReferenceException ex)
            {
                return NotFound(ex.Message);
            }
            
        }

        [HttpPut]
        public async Task<ActionResult> UpdateEmployee(Employee emp)
        {
            try
            {
                await service.UpdateEmployee(emp);
                return Ok();
            }
            catch (NullReferenceException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> AddEmployee(Employee emp)
        {
            try
            {
                await service.AddEmployee(emp);
                return Ok();
            }
            catch (NullReferenceException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteEmployee(int id)
        {
            try
            {
                await service.DeleteEmployee(id);
                return Ok();
            }
            catch (NullReferenceException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
