using _0_Framework.Application;
using System.Collections.Generic;

namespace AccountManagement.Application.Contracts.Electrical_System.Shared_Meter
{
    public interface IShared_MeterApplication
    {
        OperationResult Create(Shared_MeterCreate command);
        OperationResult Edit(Shared_MeterEdit command);
        Shared_MeterEdit GetDetails(int id);
        List<Shared_MeterViewModel> GetViewModel();
        void Remove(int id);
        void Activate(int id);
        OperationResult Total_Rest();
    }
}