using _0_Framework.Application;
using System.Collections.Generic;

namespace AccountManagement.Application.Contracts.Electrical_System.General_Meter
{
    public interface IPayApplication
    {
        OperationResult Create(PayCreate command);
        OperationResult Edit(PayEdit command);
        PayEdit GetDetails(int id);
        List<PayViewModel> GetPay();
        void Remove(int id);
        void Activate(int id);
    }
}