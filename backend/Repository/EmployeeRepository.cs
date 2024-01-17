using System.Runtime.CompilerServices;
using Dto;
using Microsoft.AspNetCore.Mvc;
using Models;
using MySql.Data.MySqlClient;
using repositorie;


namespace Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private static readonly string DbName = "Test";
        private static readonly string TableName = "employees";
        private static readonly string EmployeeId = "EmployeeId";
        private static readonly string EmployeeName = "EmployeeName";
        private static readonly string DepartementName = "DepartementName";
        private static readonly string Salary = "Salary";
        private string sqlDataSource;
        private readonly IConfiguration configuration;

        public EmployeeRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
            sqlDataSource = configuration.GetConnectionString("EmployeeAppCon");

        }



        public async Task<Employee?> GetEmployeeAsync(int id)
        {
            string query = "SELECT * From " + DbName + "." + TableName + " WHERE EmployeeId=@EmployeeId";
            Employee emp = new Employee();
            using (MySqlConnection connection = new MySqlConnection(sqlDataSource))
            {
                await connection.OpenAsync();
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@EmployeeId", id);
                    using (MySqlDataReader reader = (MySqlDataReader)await command.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            emp.EmployeeId = Convert.ToInt32(reader["EmployeeId"]);
                            emp.EmployeeName = reader["EmployeeName"].ToString();
                            emp.DepartmenetName = reader["DepartementName"].ToString();
                            emp.Salary = Convert.ToInt32(reader["Salary"]);
                        }
                        else
                        {
                            return null;
                        }
                    }
                }
            }
            return emp;
        }
        public async Task<List<EmployeeDto>> GetAllEmployeeAsync()
        {
            string query = "SELECT " + EmployeeId + "," + EmployeeName + "," + Salary + "," + DepartementName + " FROM " + DbName + "." + TableName;
            List<EmployeeDto> employees = new List<EmployeeDto>();
            using (MySqlConnection connection = new MySqlConnection(sqlDataSource))
            {
                await connection.OpenAsync();
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    using (MySqlDataReader reader = (MySqlDataReader)await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            employees.Add(new EmployeeDto
                            {
                                EmployeeId = Convert.ToInt32(reader[EmployeeId]),
                                EmployeeName = reader[EmployeeName].ToString(),
                                Salary = Convert.ToInt32(reader[Salary]),
                                DepartmentName = reader[DepartementName].ToString()
                            });
                        }
                    }
                }
            }
            return employees;
        }
        public async Task<IActionResult> InsertEmployeeDataAsync(CreateEmployeeDto employee)
        {
            try
            {
                string sqlDataSource = configuration.GetConnectionString("EmployeeAppCon");
                string query = "INSERT INTO " + TableName + " (" + EmployeeName + ", " + DepartementName + ", " + Salary + ") VALUES (@EmployeeName, @DepartementName, @Salary)";
                using (MySqlConnection connection = new MySqlConnection(sqlDataSource))
                {
                    await connection.OpenAsync();
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@EmployeeName", employee.EmployeeName);
                        command.Parameters.AddWithValue("@DepartementName", employee.DepartmentName);
                        command.Parameters.AddWithValue("@Salary", employee.Salary);
                        await command.ExecuteNonQueryAsync();
                    }
                }
                return new OkResult();
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
        }


        public async Task<IActionResult> UpdateEmployeeAsync(int id, UpdateEmployeeDto employee)
        {
            try
            {
                string query = "UPDATE " + DbName + "." + TableName + " SET " + EmployeeName + " = @EmployeeName, " + Salary + " = @Salary WHERE " + EmployeeId + " = @DepartementId";
                using (MySqlConnection mycon = new MySqlConnection(sqlDataSource))
                {
                    await mycon.OpenAsync();
                    using (MySqlCommand myCommand = new MySqlCommand(query, mycon))
                    {
                        myCommand.Parameters.AddWithValue("@DepartementId", id);
                        myCommand.Parameters.AddWithValue("@EmployeeName", employee.EmployeeName);
                        myCommand.Parameters.AddWithValue("@Salary", employee.Salary);
                        var affectedRows = await myCommand.ExecuteNonQueryAsync();
                        if (affectedRows > 0)
                        {
                            return new NoContentResult();
                        }
                        else
                        {
                            return new NotFoundResult();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
        }
        public async Task<IActionResult> DeleteEmployeeAsync(int id)
        {
            try
            {
                string query = "DELETE FROM " + DbName + "." + TableName + " WHERE " + EmployeeId + " = @DepartmentId";
                using (MySqlConnection mycon = new MySqlConnection(sqlDataSource))
                {
                    mycon.Open();
                    using (MySqlCommand myCommand = new MySqlCommand(query, mycon))
                    {
                        myCommand.Parameters.AddWithValue("@DepartmentId", id);
                        var affectedRows = myCommand.ExecuteNonQuery();
                        if (affectedRows > 0)
                        {
                            return new NoContentResult();
                        }
                        else
                        {
                            return new NotFoundResult();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
        }


    }
}
