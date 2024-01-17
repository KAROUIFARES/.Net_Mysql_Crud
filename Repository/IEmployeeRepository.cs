using Dto;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace repositorie
{
    public interface IEmployeeRepository
    {
        Task<List<EmployeeDto>> GetAllEmployeeAsync();
        Task<IActionResult> InsertEmployeeDataAsync(CreateEmployeeDto employee);
        Task<Employee> GetEmployeeAsync(int id);
        Task<IActionResult> UpdateEmployeeAsync(int id, UpdateEmployeeDto employee);
        Task DeleteEmployeeAsync(int id);
    }
}