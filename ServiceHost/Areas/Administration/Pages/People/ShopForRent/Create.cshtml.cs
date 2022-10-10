using AccountManagement.Application.Contracts.Locations;
using AccountManagement.Application.Contracts.Money;
using AccountManagement.Application.Contracts.Shop;
using AccountManagement.Application.Contracts.Shop_For_Rent;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;

namespace ServiceHost.Areas.Administration.Pages.Account.ShopForRent
{
    [Authorize(Roles = "1 , 2")]
    public class CreateModel : PageModel
    {
        public SelectList Moneys;
        public SelectList Shops;
        public SelectList Locations;
        private readonly IMoneyApplication _moneyApplication;
        private readonly IShop_Application _shopApplication;
        private readonly IShop_For_RentApplication _shop_For_RentApplication;
        private readonly ILocation_Application _location_Application;
        public CreateModel(IMoneyApplication moneyApplication, IShop_Application shopApplication,
            IShop_For_RentApplication shop_For_RentApplication, ILocation_Application location_Application)
        {
            _moneyApplication = moneyApplication;
            _shopApplication = shopApplication;
            _shop_For_RentApplication = shop_For_RentApplication;
            _location_Application = location_Application;
        }
        public void OnGet()
        {
            var shop = _shopApplication.GetShop();
            if (shop.Count !=0)
            {
                Moneys = new SelectList(_moneyApplication.GetMoney(), "Id", "Name");
                Locations = new SelectList(_location_Application.GetViewModel(), "Id", "Name");
            }
        }
        public IActionResult OnGetLocation(int location)
        {
            var result = _shopApplication.GetLocations(location).Where(x => x.Sold == false && x.Rent == false);
            return new JsonResult(result);
        }
        public IActionResult OnPost(Create_ShopForRent command)
        {
            _shop_For_RentApplication.Create(command);
            return RedirectToPage("./Create");
        }
    }
}