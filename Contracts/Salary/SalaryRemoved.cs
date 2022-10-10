using System.Collections.Generic;

namespace AccountManagement.Application.Contracts.Salary
{
    public class SalaryRemoved
    {
        public List<SalaryViewModel> Salarys { get; set; }
        public int Id { get; set; }
    }
}