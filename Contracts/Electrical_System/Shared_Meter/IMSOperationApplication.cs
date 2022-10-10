using _0_Framework.Application;
using System.Collections.Generic;

namespace AccountManagement.Application.Contracts.Electrical_System.Shared_Meter
{
    public interface IMSOperationApplication
    {
        OperationResult Create(MSOperationCreate command);
        OperationResult Edit(MSOperationEdit command);
        MSOperationEdit GetDetails(int id);
        List<MSOperationViewModel> GetOperation();
        void Remove(int id);
        void Activate(int id);
    }
}