using Dto;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using repositorie;


namespace DepartementController
{
    [ApiController]
    [Route("Department")]
    [EnableCors("AllowOrigin")]
    public class DepartmentController : ControllerBase
    {

        private readonly IEmployeeRepository employeeRepository;

        public DepartmentController(IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetDepartments()
        {
            var employees = await employeeRepository.GetEmployeeAsync();
            return Ok(employees);
        }


        // [HttpPost]
        // public IActionResult Post([FromBody] DepartmentDto department)
        // {
        //     try
        //     {
        //         string query = "INSERT INTO Test.Departement (EmployeeName, DepartementName, Salary) VALUES (@EmployeeName, @DepartementName, @Salary)";
        //         string sqlDataSource = _configuration.GetConnectionString("EmployeeAppCon");

        //         using (MySqlConnection mycon = new MySqlConnection(sqlDataSource))
        //         {
        //             mycon.Open();
        //             using (MySqlCommand myCommand = new MySqlCommand(query, mycon))
        //             {
        //                 myCommand.Parameters.AddWithValue("@EmployeeName", department.EmployeeName);
        //                 myCommand.Parameters.AddWithValue("@DepartementName", department.DepartementName);
        //                 myCommand.Parameters.AddWithValue("@Salary", department.Salary);
        //                 myCommand.ExecuteNonQuery();
        //             }
        //         }

        //         // Assuming DepartementId is auto-incrementing, so we don't need to return it here
        //         return NoContent();
        //     }
        //     catch (Exception ex)
        //     {
        //         return BadRequest(ex.Message);
        //     }
        // }

        // [HttpGet("{id}", Name = "GetDepartment")]
        // public IActionResult Get(int id)
        // {
        //     try
        //     {
        //         string query = "SELECT DepartementId, DepartementName, EmployeeName, Salary FROM Test.Departement WHERE DepartementId = @DepartmentId";
        //         string sqlDataSource = _configuration.GetConnectionString("EmployeeAppCon");
        //         DepartmentDto department = new DepartmentDto();

        //         using (MySqlConnection mycon = new MySqlConnection(sqlDataSource))
        //         {
        //             mycon.Open();
        //             using (MySqlCommand myCommand = new MySqlCommand(query, mycon))
        //             {
        //                 myCommand.Parameters.AddWithValue("@DepartmentId", id);
        //                 using (MySqlDataReader myReader = myCommand.ExecuteReader())
        //                 {
        //                     if (myReader.Read())
        //                     {
        //                         department.DepartementId = Convert.ToInt32(myReader["DepartementId"]);
        //                         department.DepartementName = myReader["DepartementName"].ToString();
        //                         department.EmployeeName = myReader["EmployeeName"].ToString();
        //                         department.Salary = Convert.ToInt32(myReader["Salary"]);
        //                     }
        //                     else
        //                     {
        //                         return NotFound();
        //                     }
        //                 }
        //             }
        //         }

        //         return new JsonResult(department);
        //     }
        //     catch (Exception ex)
        //     {
        //         return BadRequest(ex.Message);
        //     }
        // }

        // [HttpPut("{id}")]
        // public IActionResult Put(int id, [FromBody] DepartmentDto department)
        // {
        //     try
        //     {
        //         string query = "UPDATE Test.Departement SET EmployeeName = @EmployeeName, DepartementName = @DepartementName, Salary = @Salary WHERE DepartementId = @DepartementId";
        //         string sqlDataSource = _configuration.GetConnectionString("EmployeeAppCon");

        //         using (MySqlConnection mycon = new MySqlConnection(sqlDataSource))
        //         {
        //             mycon.Open();
        //             using (MySqlCommand myCommand = new MySqlCommand(query, mycon))
        //             {
        //                 myCommand.Parameters.AddWithValue("@DepartementId", id);
        //                 myCommand.Parameters.AddWithValue("@EmployeeName", department.EmployeeName);
        //                 myCommand.Parameters.AddWithValue("@DepartementName", department.DepartementName);
        //                 myCommand.Parameters.AddWithValue("@Salary", department.Salary);
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
