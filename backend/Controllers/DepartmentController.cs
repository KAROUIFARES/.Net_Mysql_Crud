using Dto;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using repositorie;
namespace DepartementController
{
    [ApiController]
    [Route("Employees")]
    [EnableCors("AllowOrigin")]
    public class DepartmentController : ControllerBase
    {
        private readonly IEmployeeRepository employeeRepository;

        public DepartmentController(IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }
        [HttpGet]
        public async Task<IEnumerable<EmployeeDto>> GetAllEmpoyeeAsync()
        {
            var employees = await employeeRepository.GetAllEmployeeAsync();
            return employees;
        }
        [HttpPost]
        public async Task<IActionResult> InsertEmployeeAsync(CreateEmployeeDto emp)
        {
            return await employeeRepository.InsertEmployeeDataAsync(emp);
        }
        [Route("getEmployee")]
        [HttpGet]
        public async Task<IActionResult> GetEmployeeAsync(int id)
        {
            var employee = await employeeRepository.GetEmployeeAsync(id);
            if (employee is null) { return NotFound(); }
            return Ok(employee);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmployee(int id, [FromBody] UpdateEmployeeDto emp)
        {
            return await employeeRepository.UpdateEmployeeAsync(id, emp);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            return await employeeRepository.DeleteEmployeeAsync(id);
        }

    }
}
