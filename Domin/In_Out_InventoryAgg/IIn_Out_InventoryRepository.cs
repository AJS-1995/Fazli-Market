using _0_Framework.Domain;
using AccountManagement.Application.Contracts.In_Out_Inventory;
using System.Collections.Generic;

namespace Domin.In_Out_InventoryAgg
{
    public interface IIn_Out_InventoryRepository : IRepository<int, In_Out_Inventory>
    {
        List<In_Out_InventoryViewModel> GetIn_Out_Inventory();
        In_Out_InventoryPhoto GetPhoto(int id);
        In_Out_InventoryEdit GetDetails(int id);
    }
}