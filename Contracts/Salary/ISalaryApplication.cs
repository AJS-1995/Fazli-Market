using _0_Framework.Application;
using System.Collections.Generic;

namespace AccountManagement.Application.Contracts.Salary
{
    public interface ISalaryApplication
    {
        OperationResult Create(SalaryCreate command);
        OperationResult Edit(SalaryEdit command);
        SalaryEdit GetDetails(int id);
        List<SalaryViewModel> GetViewModel();
        void Remove(int id);
        void Activate(int id);
    }
}