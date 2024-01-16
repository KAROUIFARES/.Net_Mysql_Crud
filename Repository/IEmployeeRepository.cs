using Microsoft.AspNetCore.Mvc;
using Models;

namespace repositorie
{
    public interface IEmployeeRepository
    {
        Task<IActionResult> GetEmployeeAsync();
        Task InsertEmployeAsync(Employee employee);
        Task<Employee> GetAllEmployeeAsync(int id);
        Task UpdateEmployeeAsync(Employee employee);
        Task DeleteEmployeeAsync(int id);
    }
}