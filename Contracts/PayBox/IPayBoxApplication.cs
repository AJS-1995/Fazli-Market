using _0_Framework.Application;
using System.Collections.Generic;

namespace AccountManagement.Application.Contracts.PayBox
{
    public interface IPayBoxApplication
    {
        OperationResult Create(PayBox_Create command);
        OperationResult Edit(Edit_PayBox command);
        Edit_PayBox GetDetails(int id);
        List<ViewModel_PayBox> GetPayBox();
        void Remove(int id);
        void Activate(int id);
    }
}