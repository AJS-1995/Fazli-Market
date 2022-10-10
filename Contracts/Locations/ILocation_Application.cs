using _0_Framework.Application;
using System.Collections.Generic;

namespace AccountManagement.Application.Contracts.Locations
{
    public interface ILocation_Application
    {
        OperationResult Create(Create_Location command);
        OperationResult Edit(Edit_Location command);
        List<ViewModel_Location> GetViewModel();
        Edit_Location GetDetails(int id);
        void Remove(int id);
        void Activate(int id);
    }
}