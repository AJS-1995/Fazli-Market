using _0_Framework.Domain;

namespace Domin.EmployeeAgg
{
    public class Employee : EntityBase<int>
    {
        public string FullName { get; private set; }
        public string Phone { get; private set; }
        public string Address { get; private set; }
        public decimal Salary { get; private set; }
        public decimal Rest { get; private set; }
        public int Money_Id { get; private set; }
        public bool Access { get; private set; }
        public string Date { get; private set; }

        public Employee(string fullName, string phone, string address, decimal salary, int money_Id, int user_Id, string date)
        {
            FullName = fullName;
            Phone = phone;
            Address = address;
            Salary = salary;
            Money_Id = money_Id;
            User_Id = user_Id;
            Access = true;
            Date = date;
        }
        public void Edit(string fullName, string phone, string address, decimal salary, int money_Id, int user_Id, string date)
        {
            FullName = fullName;
            Phone = phone;
            Address = address;
            Salary = salary;
            Money_Id = money_Id;
            User_Id = user_Id;
            Date = date;
        }
        public void Edit(string date)
        {
            Date = date;
        }
        public void Edit(decimal rest)
        {
            Rest = rest;
        }
        public void Remove()
        {
            Status = false;
        }
        public void Activate()
        {
            Status = true;
        }
        public void AccessTrue()
        {
            Access = true;
        }
        public void AccessFalse()
        {
            Access = false;
        }
    }
}