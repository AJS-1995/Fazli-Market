using _0_Framework.Application;
using System.Collections.Generic;

namespace AccountManagement.Application.Contracts.Electrical_System.General_Meter
{
    public interface IOperationApplication
    {
        OperationResult Create(OperationCreate command);
        OperationResult Edit(OperationEdit command);
        OperationEdit GetDetails(int id);
        List<OperationViewModel> GetOperation();
        void Remove(int id);
        void Activate(int id);
    }
}
