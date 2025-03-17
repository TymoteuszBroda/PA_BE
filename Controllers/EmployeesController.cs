using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PermAdminAPI.Data;
using PermAdminAPI.Models;

namespace PermAdminAPI.Controllers
{
    public class EmployeesController(DataContext context) : BaseApiController
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployees()
        {
            var employees = await context.Employees.ToListAsync();
            return Ok(employees);
        }
    
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Employee>> GetEmployeeById(int id)
        {
            var employee = await context.Employees.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            return Ok(employee);
        }

        [HttpPost]
        public async Task<ActionResult<Employee>> AddEmployee(Employee employee)
        {
            if (employee == null)
            {
                return BadRequest("Employee data is required.");
            }

            context.Employees.Add(employee);
            await context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetEmployeeById), new { id = employee.id }, employee);
        }
    }
}
