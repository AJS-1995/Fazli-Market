using _0_Framework.Application;
using System.Collections.Generic;

namespace AccountManagement.Application.Contracts.Electrical_System.General_Meter
{
    public interface IGeneralMeterApplication
    {
        OperationResult Create(GeneralMeterCreate command);
        OperationResult Edit(GeneralMeterEdit command);
        GeneralMeterEdit GetDetails(int id);
        List<GeneralMeterViewModel> GetGeneralMeter();
        void Remove(int id);
        void Activate(int id);
        OperationResult Total_Rest();
    }
}
