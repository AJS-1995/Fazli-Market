using System.Collections.Generic;
using System.Linq;
using AccountManagement.Application.Contracts.In_Out_Inventory;
using AccountManagement.Application.Contracts.Inventory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Areas.Administration.Pages.Book.Inventorys
{
    public class IndexModel : PageModel
    {
        public List<InventoryViewModel> inventorys;

        private readonly IInventoryApplication _inventoryApplication;

        public IndexModel(IInventoryApplication inventoryApplication)
        {
            _inventoryApplication = inventoryApplication;
        }

        public void OnGet()
        {
            inventorys = _inventoryApplication.GetInventory().Where(x => x.Status == true).ToList();
        }
        public IActionResult OnGetCreate()
        {
            return Partial("./Create");
        }
        public IActionResult OnPostCreate(CreateInventory command)
        {
            _inventoryApplication.Create(command);
            return RedirectToPage("./Index");
        }
        public IActionResult OnGetEdit(int id)
        {
            var account = _inventoryApplication.GetDetails(id);
            return Partial("./Edit", account);
        }
        public IActionResult OnPostEdit(InventoryEdit command)
        {
            _inventoryApplication.Edit(command);
            return RedirectToPage("./Index");
        }
        public IActionResult OnGetRemoved()
        {
            var commnd = new Removed()
            {
                Inventorys = _inventoryApplication.GetInventory().Where(x => x.Status == false).ToList(),
            };
            return Partial("./Removed", commnd);
        }
        public RedirectToPageResult OnGetRemove(int id)
        {
            _inventoryApplication.Remove(id);
            return RedirectToPage("./Index");
        }
        public RedirectToPageResult OnGetActivate(int id)
        {
            _inventoryApplication.Activate(id);
            return RedirectToPage("./Index");
        }
    }
}