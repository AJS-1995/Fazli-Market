using _0_Framework.Application;
using System.Collections.Generic;

namespace AccountManagement.Application.Contracts.Electrical_System.Box_Meter
{
    public interface IBoxMeterApplication
    {
        OperationResult Create(BoxMeterCreate command);
        OperationResult Edit(BoxMeterEdit command);
        List<BoxMeterViewModel> GetViewModel();
        BoxMeterEdit GetDetails(int id);
        void Remove(int id);
        void Activate(int id);
    }
}