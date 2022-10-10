using AccountManagement.Application.Contracts.Inventory;
using System.Collections.Generic;

namespace AccountManagement.Application.Contracts.In_Out_Inventory
{
    public class Removed
    {
        public List<In_Out_InventoryViewModel> In_Out_Inventorys { get; set; }
        public List<InventoryViewModel> Inventorys { get; set; }
        public int Id { get; set; }
    }
}