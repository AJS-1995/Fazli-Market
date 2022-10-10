using _0_Framework.Domain;
using AccountManagement.Application.Contracts.Salary;
using System.Collections.Generic;

namespace Domin.SalaryAgg
{
    public interface ISalaryRepository : IRepository<int, Salary>
    {
        SalaryEdit GetDetails(int id);
        List<SalaryViewModel> GetViewModel();
    }
}