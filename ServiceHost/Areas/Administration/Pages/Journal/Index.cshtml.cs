using _0_Framework.Application;
using AccountManagement.Application.Contracts.Expense;
using AccountManagement.Application.Contracts.In_Out_Inventory;
using AccountManagement.Application.Contracts.Inventory;
using AccountManagement.Application.Contracts.Locations;
using AccountManagement.Application.Contracts.Money;
using AccountManagement.Application.Contracts.ReceiptRent;
using AccountManagement.Application.Contracts.Shop;
using AccountManagement.Application.Contracts.Shop_For_Rent;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Linq;

namespace ServiceHost.Areas.Administration.Pages.Journal
{
    public class IndexModel : PageModel
    {
        public SelectList Moneys;
        public SelectList Inventorys;
        public SelectList Shops;
        public SelectList Locations;

        private readonly IMoneyApplication _moneyApplication;
        private readonly IInventoryApplication _inventoryApplication;
        private readonly IIn_Out_InventoryApplication _in_Out_InventoryApplication;
        private readonly IExpenseApplication _expenseApplication;
        private readonly IShop_Application _shopApplication;
        private readonly ILocation_Application _location_Application;
        private readonly IShop_For_RentApplication _shop_For_RentApplication;
        private readonly IReceiptRentApplication _receiptRentApplication;

        public IndexModel(
            IMoneyApplication moneyApplication, IInventoryApplication inventoryApplication,
            IIn_Out_InventoryApplication in_Out_InventoryApplication, IExpenseApplication expenseApplication, IShop_Application shopApplication,
            ILocation_Application location_Application, IShop_For_RentApplication shop_For_RentApplication, IReceiptRentApplication receiptRentApplication)
        {
            _moneyApplication = moneyApplication;
            _inventoryApplication = inventoryApplication;
            _in_Out_InventoryApplication = in_Out_InventoryApplication;
            _expenseApplication = expenseApplication;
            _shopApplication = shopApplication;
            _location_Application = location_Application;
            _shop_For_RentApplication = shop_For_RentApplication;
            _receiptRentApplication = receiptRentApplication;
        }

        public void OnGet()
        {
            Moneys = new SelectList(_moneyApplication.GetMoney(), "Id", "Name");
            Inventorys = new SelectList(_inventoryApplication.GetInventory(), "Id", "Name");
            Locations = new SelectList(_location_Application.GetViewModel(), "Id", "Name");
        }
        public IActionResult OnPostCreateInOutInventory(CreateIn_Out_Inventory command)
        {
            command.Date = DateTime.Now.ToFarsi();
            _in_Out_InventoryApplication.Create(command);
            return RedirectToPage("./Index");
        }
        public IActionResult OnPostCreateExpenses(ExpenseCreate command)
        {
            command.Date = DateTime.Now.ToFarsi();
            _expenseApplication.Create(command);
            return RedirectToPage("./Index");
        }
        public IActionResult OnGetLocation(int location)
        {
            var result = _shopApplication.GetLocations(location).Where(x => x.Rent == true);
            return new JsonResult(result);
        }
        public IActionResult OnGetShopId(int shop_id)
        {
            var shop = _shopApplication.GetDetails(shop_id);
            var result = _shop_For_RentApplication.GetDetails(shop.Id_Shopkeeper);
            result.Money = _moneyApplication.GetDetails(result.Money_Id)?.Name;
            return new JsonResult(result);
        }
        public IActionResult OnPostCreateReceiptRent(ReceiptRentCreate command)
        {
            command.Date = DateTime.Now.ToFarsi();
            _receiptRentApplication.Create(command);
            return RedirectToPage("./Index");
        }
    }
}