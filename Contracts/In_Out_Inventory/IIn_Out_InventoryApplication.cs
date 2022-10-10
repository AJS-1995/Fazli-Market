using _0_Framework.Application;
using System.Collections.Generic;

namespace AccountManagement.Application.Contracts.In_Out_Inventory
{
    public interface IIn_Out_InventoryApplication
    {
        OperationResult Create(CreateIn_Out_Inventory command);
        OperationResult Edit(In_Out_InventoryEdit command);
        In_Out_InventoryEdit GetDetails(int id);
        In_Out_InventoryPhoto GetPhoto(int id);
        List<In_Out_InventoryViewModel> GetIn_Out_Inventory();
        void Remove(int id);
        void Activate(int id);
    }
}