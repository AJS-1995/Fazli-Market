using _0_Framework.Application;
using AccountManagement.Application.Contracts.Money;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AccountManagement.Application.Contracts.Employee
{
    public class EmployeeCreate
    {
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string FullName { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Date { get; set; }
        public decimal Salary { get; set; }
        public int Money_Id { get; set; }
        public List<MoneyViewModel> Moneys { get; set; }
    }
}