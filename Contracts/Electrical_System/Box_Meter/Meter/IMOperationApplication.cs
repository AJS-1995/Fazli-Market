using _0_Framework.Application;
using System.Collections.Generic;

namespace AccountManagement.Application.Contracts.Electrical_System.Box_Meter.Meter
{
    public interface IMOperationApplication
    {
        OperationResult Create(MOperationCreate command);
        OperationResult Edit(MOperationEdit command);
        MOperationEdit GetDetails(int id);
        List<MOperationViewModel> GetOperation();
        void Remove(int id);
        void Activate(int id);
    }
}