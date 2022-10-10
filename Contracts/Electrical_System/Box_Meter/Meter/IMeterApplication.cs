using _0_Framework.Application;
using System.Collections.Generic;

namespace AccountManagement.Application.Contracts.Electrical_System.Box_Meter.Meter
{
    public interface IMeterApplication
    {
        OperationResult Create(MeterCreate command);
        OperationResult Edit(MeterEdit command);
        MeterEdit GetDetails(int id);
        List<MeterViewModel> GetViewModel();
        void Remove(int id);
        void Activate(int id);
        OperationResult Total_Rest();
    }
}