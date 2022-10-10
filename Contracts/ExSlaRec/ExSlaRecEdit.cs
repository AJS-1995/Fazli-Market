using AccountManagement.Application.Contracts.Employee;
using AccountManagement.Application.Contracts.Money;
using System.Collections.Generic;

namespace AccountManagement.Application.Contracts.ExSlaRec
{
    public class ExSlaRecEdit : ExSlaRecCreate
    {
        public int Id { get; set; }
        public List<MoneyViewModel> Moneys { get; set; }
        public List<EmployeeViewModel> Employees { get; set; }
    }
}