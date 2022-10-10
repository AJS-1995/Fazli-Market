namespace AccountManagement.Application.Contracts.Salary
{
    public class SalaryCreate
    {
        public int Money_Id { get; set; }
        public string Money { get; set; }
        public int Employee_Id { get; set; }
        public string Employee { get; set; }
        public decimal Year { get; set; }
        public decimal Month { get; set; }
        public decimal Month_Salary { get; set; }
    }
}