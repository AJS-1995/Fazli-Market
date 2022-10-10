using _0_Framework.Application;
using System.Collections.Generic;

namespace AccountManagement.Application.Contracts.Electrical_System.Box_Meter.Meter
{
    public interface IMPayApplication
    {
        OperationResult Create(MPayCreate command);
        OperationResult Edit(MPayEdit command);
        MPayEdit GetDetails(int id);
        List<MPayViewModel> GetMPay();
        void Remove(int id);
        void Activate(int id);
    }
}