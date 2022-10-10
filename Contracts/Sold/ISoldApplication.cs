using _0_Framework.Application;
using System.Collections.Generic;

namespace AccountManagement.Application.Contracts.Sold
{
    public interface ISoldApplication
    {
        OperationResult Create(Create_Sold command);
        OperationResult Edit(Edit_Sold command);
        OperationResult Empty(Edit_Sold command);
        Edit_Sold GetDetails(int id);
        List<ViewModel_Sold> GetViewModel();
        void Remove(int id);
        void Activate(int id);
    }
}