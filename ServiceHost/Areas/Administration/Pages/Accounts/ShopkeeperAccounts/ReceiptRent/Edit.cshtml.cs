using AccountManagement.Application.Contracts.Locations;
using AccountManagement.Application.Contracts.Money;
using AccountManagement.Application.Contracts.PayBox;
using AccountManagement.Application.Contracts.ReceiptRent;
using AccountManagement.Application.Contracts.Shop;
using AccountManagement.Application.Contracts.Shop_For_Rent;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;

namespace ServiceHost.Areas.Administration.Pages.PeoplesAccounts.ShopkeeperAccounts.ReceiptRent
{
    public class EditModel : PageModel
    {
        public int Id;
        public SelectList Moneys;
        public SelectList Shops;
        public SelectList Locations;
        public SelectList PayBoxs;
        public int ren = 1;
        public Edit_ShopForRent scommand;
        public Edit_Location lcommand;
        public MoneyEdit mcommand;
        public ReceiptRentEdit command;
        private readonly IReceiptRentApplication _receiptRentApplication;
        private readonly IMoneyApplication _moneyApplication;
        private readonly IShop_Application _shopApplication;
        private readonly IShop_For_RentApplication _shop_For_RentApplication;
        private readonly ILocation_Application _location_Application;
        private readonly IPayBoxApplication _payBoxApplication;
        public EditModel(IMoneyApplication moneyApplication, IShop_Application shopApplication,
            IShop_For_RentApplication shop_For_RentApplication, ILocation_Application location_Application,
            IReceiptRentApplication receiptRentApplication, IPayBoxApplication payBoxApplication)
        {
            _moneyApplication = moneyApplication;
            _shopApplication = shopApplication;
            _shop_For_RentApplication = shop_For_RentApplication;
            _location_Application = location_Application;
            _receiptRentApplication = receiptRentApplication;
            _payBoxApplication = payBoxApplication;
        }
        public void OnGet(int id)
        {
            command = _receiptRentApplication.GetDetails(id);
            Moneys = new SelectList(_moneyApplication.GetMoney().Where(x => x.Status == true), "Id", "Name");
            Locations = new SelectList(_location_Application.GetViewModel().Where(x => x.Status == true), "Id", "Name");
            scommand = _shop_For_RentApplication.GetDetails(command.ForRent_Id);
            PayBoxs = new SelectList(_payBoxApplication.GetPayBox().Where(x => x.Status == true && x.Money_Id == scommand.Money_Id).ToList(), "Id", "Name");
            var shopa = _shopApplication.GetDetails(command.Shop_Id);
            lcommand = _location_Application.GetDetails(shopa.Location_Id);
            mcommand = _moneyApplication.GetDetails(scommand.Money_Id);
            Shops = new SelectList(_shopApplication.GetLocations(lcommand.Id), "Id", "Name");
            Id = id;
        }
        public RedirectToPageResult OnPost(ReceiptRentEdit command)
        {
            _receiptRentApplication.Edit(command);
            return RedirectToPage("./Index", new { id = command.ForRent_Id });
        }
    }
}