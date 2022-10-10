using _0_Framework.Application;
using System.Collections.Generic;

namespace AccountManagement.Application.Contracts.Inventory
{
    public interface IInventoryApplication
    {
        OperationResult Create(CreateInventory command);
        OperationResult Edit(InventoryEdit command);
        InventoryEdit GetDetails(int id);
        List<InventoryViewModel> GetInventory();
        void Remove(int id);
        void Activate(int id);
    }
}
