using Dto;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Models;
using MySql.Data.MySqlClient;
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


        // [HttpDelete("{id}")]
        // public IActionResult Delete(int id)
        // {
        //     try
        //     {
        //         string query = "DELETE FROM Test.Departement WHERE DepartementId = @DepartmentId";
        //         string sqlDataSource = _configuration.GetConnectionString("EmployeeAppCon");

        //         using (MySqlConnection mycon = new MySqlConnection(sqlDataSource))
        //         {
        //             mycon.Open();
        //             using (MySqlCommand myCommand = new MySqlCommand(query, mycon))
        //             {
        //                 myCommand.Parameters.AddWithValue("@DepartmentId", id);
        //                 var affectedRows = myCommand.ExecuteNonQuery();

        //                 if (affectedRows > 0)
        //                 {
        //                     return NoContent();
        //                 }
        //                 else
        //                 {
        //                     return NotFound();
        //                 }
        //             }
        //         }
        //     }
        //     catch (Exception ex)
        //     {
        //         return BadRequest(ex.Message);
        //     }
        // }

    }
}
