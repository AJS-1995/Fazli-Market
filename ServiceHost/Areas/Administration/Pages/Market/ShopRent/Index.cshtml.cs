using System.Collections.Generic;
using System.Linq;
using AccountManagement.Application.Contracts.Locations;
using AccountManagement.Application.Contracts.Money;
using AccountManagement.Application.Contracts.Shop;
using AccountManagement.Application.Contracts.Shop_For_Rent;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Areas.Administration.Pages.Market.ShopRent
{
    public class IndexModel : PageModel
    {
        public List<ViewModel_Shop> shops;

        private readonly IShop_Application _shopApplication;
        private readonly IShop_For_RentApplication _shop_For_RentApplication;
        private readonly ILocation_Application _location_Application;
        private readonly IMoneyApplication _moneyApplication;
        public IndexModel(IShop_Application shopApplication, IShop_For_RentApplication shop_For_RentApplication, ILocation_Application location_Application, IMoneyApplication moneyApplication)
        {
            _shopApplication = shopApplication;
            _shop_For_RentApplication = shop_For_RentApplication;
            _location_Application = location_Application;
            _moneyApplication = moneyApplication;
        }

        public void OnGet()
        {
            _shopApplication.Rest();
            _shop_For_RentApplication.Total_Rest();
            shops = _shopApplication.GetShop().Where(x => x.Status == true && x.Sold == false).ToList();
        }
        public IActionResult OnGetFull(int id)
        {
            var shop = _shopApplication.GetDetails(id);
            var command = new Create_ShopForRent
            {
                LocationName = _location_Application.GetDetails(shop.Location_Id).Name,
                ShopName = shop.Name,
                Shop_Id = id,
                Moneys = _moneyApplication.GetMoney().Where(x => x.Status == true).ToList(),
            };
            return Partial("./Full", command);
        }
        public IActionResult OnPostFull(Create_ShopForRent command)
        {
            _shop_For_RentApplication.Create(command);
            return RedirectToPage("./Index");
        }
        public IActionResult OnGetEmpty(int id)
        {
            var shop = _shopApplication.GetDetails(id);
            var command = new Edit_ShopForRent
            {
                LocationName = _location_Application.GetDetails(shop.Location_Id).Name,
                ShopName = shop.Name,
                Shop_Id = id,
                Id = shop.Id_Shopkeeper,
            };
            return Partial("./Empty", command);
        }
        public IActionResult OnPostEmpty(Edit_ShopForRent command)
        {
            _shop_For_RentApplication.Empty(command);
            return RedirectToPage("./Index");
        }
        public IActionResult OnGetTenants(int id)
        {
            var locationid = _shopApplication.GetDetails(id);
            var command = new Removed
            {
                ShopForRents = _shop_For_RentApplication.GetViewModel().Where(x => x.Status == true && x.Id_Shop == id).ToList(),
                Id = _shopApplication.GetDetails(id).Id_Shopkeeper,
                LocationName = _location_Application.GetDetails(locationid.Location_Id).Name,
                ShopName = _shopApplication.GetDetails(id).Name,
            };
            return Partial("./Tenants", command);
        }
    }
}