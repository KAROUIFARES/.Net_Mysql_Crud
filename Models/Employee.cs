namespace Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public required string EmployeeName { get; set; }
        public required string Departmenet { get; set; }
        public required string DateOfJoining { get; init; }
        public required string PhotoFileName { get; init; }
    }
}