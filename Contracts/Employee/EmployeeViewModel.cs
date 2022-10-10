namespace AccountManagement.Application.Contracts.Employee
{
    public class EmployeeViewModel
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string CreationDate { get; set; }
        public string Date { get; set; }
        public bool Status { get; set; }
        public bool Access { get; set; }
        public string UserName { get; set; }
        public int User_Id { get; set; }
        public decimal Salary { get; set; }
        public decimal Rest { get; set; }
        public int Money_Id { get; set; }
        public string Money { get; set; }
    }
}