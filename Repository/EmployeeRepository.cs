using Dto;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Models;
using MySql.Data.MySqlClient;
using repositorie;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly IConfiguration configuration;

        public EmployeeRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public Task DeleteEmployeeAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Employee> GetAllEmployeeAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IActionResult> GetEmployeeAsync()
        {
            string query = "SELECT DepartementId, EmployeeName, Salary, DepartementName FROM Test.Departement";
            List<EmployeeDto> employees = new List<EmployeeDto>();
            string sqlDataSource = configuration.GetConnectionString("EmployeeAppCon");
            using (MySqlConnection mycon = new MySqlConnection(sqlDataSource))
            {
                await mycon.OpenAsync();
                using (MySqlCommand myCommand = new MySqlCommand(query, mycon))
                {
                    using (MySqlDataReader myReader = (MySqlDataReader)await myCommand.ExecuteReaderAsync())
                    {
                        while (await myReader.ReadAsync())
                        {
                            employees.Add(new EmployeeDto
                            {
                                EmployeeId = Convert.ToInt32(myReader["DepartementId"]),
                                EmployeeName = myReader["EmployeeName"].ToString(),
                                Salary = Convert.ToInt32(myReader["Salary"]),
                                DepartmentName = myReader["DepartementName"].ToString()
                            });
                        }
                    }
                }
            }
            return new OkObjectResult(employees);
        }
        public Task InsertEmployeAsync(Employee employee)
        {
            throw new NotImplementedException();
        }

        public Task UpdateEmployeeAsync(Employee employee)
        {
            throw new NotImplementedException();
        }


    }
}
