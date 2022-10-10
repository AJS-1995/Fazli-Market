namespace Domin.SalaryAgg
{
    public class Salary
    {
        public int Id { get; set; }
        public int Money_Id { get; private set; }
        public int Employee_Id { get; private set; }
        public int Year { get; private set; }
        public int Month { get; private set; }
        public decimal Month_Salary { get; private set; }
        public bool Status { get; private set; }

        public Salary(int money_Id, int employee_Id, int year, int month, decimal month_Salary)
        {
            Money_Id = money_Id;
            Employee_Id = employee_Id;
            Year = year;
            Month = month;
            Month_Salary = month_Salary;
            Status = true;
        }
        public void Edit(int money_Id, int employee_Id, int year, int month, decimal month_Salary)
        {
            Money_Id = money_Id;
            Employee_Id = employee_Id;
            Year = year;
            Month = month;
            Month_Salary = month_Salary;
        }
        public void Remove()
        {
            Status = false;
        }
        public void Activate()
        {
            Status = true;
        }
    }
}