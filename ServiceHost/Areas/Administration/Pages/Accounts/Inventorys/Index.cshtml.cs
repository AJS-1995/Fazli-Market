using System.Collections.Generic;
using System.Linq;
using AccountManagement.Application.Contracts.In_Out_Inventory;
using AccountManagement.Application.Contracts.Inventory;
using AccountManagement.Application.Contracts.Money;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Areas.Administration.Pages.Accounts.Inventorys
{
    public class IndexModel : PageModel
    {
        public List<In_Out_InventoryViewModel> in_Out_Inventorys;

        private readonly IIn_Out_InventoryApplication _in_Out_InventoryApplication;
        private readonly IMoneyApplication _moneyApplication;
        private readonly IInventoryApplication _inventoryApplication;
        public IndexModel(IIn_Out_InventoryApplication in_Out_InventoryApplication, IMoneyApplication moneyApplication, IInventoryApplication inventoryApplication)
        {
            _in_Out_InventoryApplication = in_Out_InventoryApplication;
            _moneyApplication = moneyApplication;
            _inventoryApplication = inventoryApplication;
        }

        public void OnGet()
        {
            in_Out_Inventorys = _in_Out_InventoryApplication.GetIn_Out_Inventory().Where(x => x.Status == true).ToList();
        }
        public IActionResult OnGetCreate()
        {
            var commnd = new CreateIn_Out_Inventory()
            {
                Moneys = _moneyApplication.GetMoney().Where(x => x.Status == true).ToList(),
                Inventorys = _inventoryApplication.GetInventory().Where(x => x.Status == true).ToList(),
            };
            return Partial("./Create", commnd);
        }
        public IActionResult OnPostCreate(CreateIn_Out_Inventory command)
        {
            _in_Out_InventoryApplication.Create(command);
            return RedirectToPage("./Index");
        }
        public IActionResult OnGetEdit(int id)
        {
            var result = _in_Out_InventoryApplication.GetDetails(id);
            result.Moneys = _moneyApplication.GetMoney();
            result.Inventorys = _inventoryApplication.GetInventory();
            return Partial("./Edit", result);
        }
        public IActionResult OnPostEdit(In_Out_InventoryEdit command)
        {
            _in_Out_InventoryApplication.Edit(command);
            return RedirectToPage("./Index");
        }
        public IActionResult OnGetRemoved()
        {
            var commnd = new Removed()
            {
                In_Out_Inventorys = _in_Out_InventoryApplication.GetIn_Out_Inventory().Where(x => x.Status == false).ToList(),
            };
            return Partial("./Removed", commnd);
        }
        public IActionResult OnGetActivate(int id)
        {
            _in_Out_InventoryApplication.Activate(id);
            return RedirectToPage("./Index");
        }
        public IActionResult OnGetRemove(int id)
        {
            _in_Out_InventoryApplication.Remove(id);
            return RedirectToPage("./Index");
        }
        public IActionResult OnGetInvoice(int id)
        {
            var result = _in_Out_InventoryApplication.GetPhoto(id);
            return Partial("./Invoice", result);
        }
    }
}