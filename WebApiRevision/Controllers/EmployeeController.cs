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
        public async Task<Employee> Find(int id)
        {
            return await service.GetEmployeeById(id);
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
                return BadRequest(ex.Message);
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
                return BadRequest(ex.Message);
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
                return BadRequest(ex.Message);
            }
        }
    }
}
