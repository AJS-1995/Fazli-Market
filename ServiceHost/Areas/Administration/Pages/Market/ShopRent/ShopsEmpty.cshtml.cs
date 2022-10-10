using System.Collections.Generic;
using System.Linq;
using AccountManagement.Application.Contracts.Shop;
using AccountManagement.Application.Contracts.Shop_For_Rent;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Areas.Administration.Pages.Market.ShopRent
{
    public class ShopsEmptyModel : PageModel
    {
        public List<ViewModel_Shop> shops;

        private readonly IShop_Application _shopApplication;
        private readonly IShop_For_RentApplication _shop_For_RentApplication;
        public ShopsEmptyModel(IShop_Application shopApplication, IShop_For_RentApplication shop_For_RentApplication)
        {
            _shopApplication = shopApplication;
            _shop_For_RentApplication = shop_For_RentApplication;
        }
        public void OnGet()
        {
            _shopApplication.Rest();
            _shop_For_RentApplication.Total_Rest();
            shops = _shopApplication.GetShop().Where(x => x.Status == true && x.Sold == false && x.Rent == false).ToList();
        }
    }
}