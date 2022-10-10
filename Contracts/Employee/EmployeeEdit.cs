namespace AccountManagement.Application.Contracts.Employee
{
    public class EmployeeEdit : EmployeeCreate
    {
        public int Id { get; set; }
        public string Money { get; set; }
    }
}