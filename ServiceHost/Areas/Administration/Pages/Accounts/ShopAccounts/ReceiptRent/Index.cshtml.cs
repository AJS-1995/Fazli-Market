using System;
using System.Collections.Generic;
using System.Linq;
using _0_Framework.Application;
using AccountManagement.Application.Contracts.Locations;
using AccountManagement.Application.Contracts.Money;
using AccountManagement.Application.Contracts.PayBox;
using AccountManagement.Application.Contracts.ReceiptRent;
using AccountManagement.Application.Contracts.Shop;
using AccountManagement.Application.Contracts.Shop_For_Rent;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Areas.Administration.Pages.Accounts.ShopAccounts.ReceiptRent
{
    public class IndexModel : PageModel
    {
        public List<ReceiptRentViewModel> receiptRents;
        public string Location;
        public int Location_Id;
        public string Name;
        public int Id;
        private readonly IReceiptRentApplication _receiptRentApplication;
        private readonly IMoneyApplication _moneyApplication;
        private readonly IShop_Application _shopApplication;
        private readonly IShop_For_RentApplication _shop_For_RentApplication;
        private readonly ILocation_Application _location_Application;
        private readonly IPayBoxApplication _payBoxApplication;
        public IndexModel(IReceiptRentApplication receiptRentApplication, IMoneyApplication moneyApplication,
            IShop_Application shopApplication, IShop_For_RentApplication shop_For_RentApplication, ILocation_Application location_Application, IPayBoxApplication payBoxApplication)
        {
            _receiptRentApplication = receiptRentApplication;
            _moneyApplication = moneyApplication;
            _shopApplication = shopApplication;
            _shop_For_RentApplication = shop_For_RentApplication;
            _location_Application = location_Application;
            _payBoxApplication = payBoxApplication;
        }

        public void OnGet(int id)
        {
            _shopApplication.Rest();
            receiptRents = _receiptRentApplication.GetReceiptRent().Where(x => x.Status == true && x.Shop_Id == id).ToList();
            Location_Id = _shopApplication.GetDetails(id).Location_Id;
            Location = _location_Application.GetDetails(Location_Id).Name;
            Name = _shopApplication.GetDetails(id).Name;
            Id = id;
        }
        public IActionResult OnGetCreate(int id)
        {
            int location = _shopApplication.GetDetails(id).Location_Id;
            int forrent = _shopApplication.GetDetails(id).Id_Shopkeeper;
            int money = _shop_For_RentApplication.GetDetails(forrent).Money_Id;
            string date = DateTime.Now.ToFarsi();
            var year = Convert.ToInt32(date.Substring(0, 4));
            var month = Convert.ToInt32(date.Substring(5, 2));
            var commnd = new ReceiptRentCreate()
            {
                Shop_Id = id,
                Location = _location_Application.GetDetails(location).Name,
                Shop = _shopApplication.GetDetails(id).Name,
                ForRent_Id = forrent,
                ForRentName = _shop_For_RentApplication.GetDetails(forrent).Name,
                ForRentCompany = _shop_For_RentApplication.GetDetails(forrent).Company,
                Rent = _shop_For_RentApplication.GetDetails(forrent).Rent,
                Money_Id = money,
                Money = _moneyApplication.GetDetails(money).Name,
                PayBoxs = _payBoxApplication.GetPayBox().Where(x => x.Status == true && x.Money_Id == money).ToList(),
                ForRentRest = _shop_For_RentApplication.GetDetails(forrent).Rest,
                Shop_Amount = (int)_shop_For_RentApplication.GetDetails(forrent).Rent,
                Date = date,
                Years = year,
                Months = month,
            };
            return Partial("./Create", commnd);
        }
        public IActionResult OnPostCreate(ReceiptRentCreate command)
        {
            _receiptRentApplication.Create(command);
            return RedirectToPage("./Print", command);
        }
        public IActionResult OnGetEdit(int id)
        {
            var result = _receiptRentApplication.GetDetails(id);
            var Shop = _receiptRentApplication.GetDetails(id).Shop_Id;
            int location = _shopApplication.GetDetails(Shop).Location_Id;
            int forrent = _shopApplication.GetDetails(Shop).Id_Shopkeeper;
            int money = _shop_For_RentApplication.GetDetails(forrent).Money_Id;
            result.Shop_Id = Shop;
            result.Location = _location_Application.GetDetails(location).Name;
            result.Shop = _shopApplication.GetDetails(Shop).Name;
            result.ForRent_Id = forrent;
            result.ForRentName = _shop_For_RentApplication.GetDetails(forrent).Name;
            result.ForRentCompany = _shop_For_RentApplication.GetDetails(forrent).Company;
            result.Rent = _shop_For_RentApplication.GetDetails(forrent).Rent;
            result.Money_Id = money;
            result.Money = _moneyApplication.GetDetails(money).Name;
            result.PayBoxs = _payBoxApplication.GetPayBox().Where(x => x.Status == true && x.Money_Id == money).ToList();
            result.ForRentRest = _shop_For_RentApplication.GetDetails(forrent).Rest;
            return Partial("./Edit", result);
        }
        public IActionResult OnPostEdit(ReceiptRentEdit command)
        {
            _receiptRentApplication.Edit(command);
            return RedirectToPage("./Print", command);
        }
        public IActionResult OnGetRemove(int id)
        {
            _receiptRentApplication.Remove(id);
            var result = _receiptRentApplication.GetDetails(id);
            return RedirectToPage("./Index", new { id = result.Shop_Id });
        }
        public IActionResult OnGetRemoved(int id)
        {
            var commnd = new Removed()
            {
                Receipts = _receiptRentApplication.GetReceiptRent().Where(x => x.Status == false && x.Shop_Id == id).ToList(),
                Id = id,
            };
            Id = id;
            return Partial("./Removed", commnd);
        }
        public IActionResult OnGetActivate(int id)
        {
            _receiptRentApplication.Activate(id);
            var result = _receiptRentApplication.GetDetails(id);
            return RedirectToPage("./Index", new { id = result.Shop_Id });
        }
    }
}