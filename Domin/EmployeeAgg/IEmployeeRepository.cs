using _0_Framework.Domain;
using AccountManagement.Application.Contracts.Employee;
using System.Collections.Generic;

namespace Domin.EmployeeAgg
{
    public interface IEmployeeRepository : IRepository<int,Employee>
    {
        List<EmployeeViewModel> GetEmployee();
        EmployeeEdit GetDetails(int id);
    }
}