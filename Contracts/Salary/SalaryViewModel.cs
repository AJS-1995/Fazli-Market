namespace AccountManagement.Application.Contracts.Salary
{
    public class SalaryViewModel
    {
        public int Id { get; set; }
        public int Money_Id { get; set; }
        public string Money { get; set; }
        public int Employee_Id { get; set; }
        public string Employee { get; set; }
        public int Year { get; set; }
        public string Month { get; set; }
        public decimal Month_Salary { get; set; }
        public bool Status { get; set; }
    }
}