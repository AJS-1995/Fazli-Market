using _0_Framework.Domain;
using AccountManagement.Application.Contracts.Inventory;
using System.Collections.Generic;

namespace Domin.InventoryAgg
{
    public interface IInventoryRepository : IRepository<int, Inventory>
    {
        List<InventoryViewModel> GetInventory();
        InventoryEdit GetDetails(int id);
    }
}