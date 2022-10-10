using _0_Framework.Application;
using System.Collections.Generic;

namespace AccountManagement.Application.Contracts.Employee
{
    public interface IEmployeeApplication
    {
        OperationResult Create(EmployeeCreate command);
        OperationResult Edit(EmployeeEdit command);
        EmployeeEdit GetDetails(int id);
        List<EmployeeViewModel> GetEmployee();
        void Remove(int id);
        void Activate(int id);
        OperationResult Total_Rest();
        void AccessTrue(int id);
        void AccessFalse(int id);
    }
}