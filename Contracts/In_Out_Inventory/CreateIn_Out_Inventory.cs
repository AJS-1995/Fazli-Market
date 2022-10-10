using AccountManagement.Application.Contracts.Inventory;
using AccountManagement.Application.Contracts.Money;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace AccountManagement.Application.Contracts.In_Out_Inventory
{
    public class CreateIn_Out_Inventory
    {
        public string Date { get; set; }
        public string Details { get; set; }
        public string By { get; set; }
        public float Amount { get; set; }
        public decimal Sum { get; set; }
        public string Type { get; set; }
        public IFormFile Ph_Invoice { get; set; }
        public int MoneyId { get; set; }
        public int InventoryId { get; set; }
        public int UserId { get; set; }
        public List<MoneyViewModel> Moneys { get; set; }
        public List<InventoryViewModel> Inventorys { get; set; }
    }
}