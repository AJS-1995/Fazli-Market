using _0_Framework.Application;
using System.Collections.Generic;

namespace AccountManagement.Application.Contracts.PayBox
{
    public interface ITransfersPayBoxApplication
    {
        OperationResult Create(TransfersPayBox_Create command);
        OperationResult Edit(Edit_TransfersPayBox command);
        Edit_TransfersPayBox GetDetails(int id);
        List<ViewModel_TransfersPayBox> GetTransfersPayBox();
        void Remove(int id);
        void Activate(int id);
    }
}