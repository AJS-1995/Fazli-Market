using System.Collections.Generic;
using System.Linq;
using AccountManagement.Application.Contracts.Locations;
using AccountManagement.Application.Contracts.Shop;
using AccountManagement.Application.Contracts.Sold;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Areas.Administration.Pages.Market.ShopSold
{
    public class IndexModel : PageModel
    {
        public List<ViewModel_Shop> shops;

        private readonly IShop_Application _shopApplication;
        private readonly ISoldApplication _soldApplication;
        private readonly ILocation_Application _location_Application;
        public IndexModel(IShop_Application shopApplication, ILocation_Application location_Application, ISoldApplication soldApplication)
        {
            _shopApplication = shopApplication;
            _location_Application = location_Application;
            _soldApplication = soldApplication;
        }

        public void OnGet()
        {
            shops = _shopApplication.GetShop().Where(x => x.Status == true && x.Sold == true).ToList();
        }
        public IActionResult OnGetFull(int id)
        {
            var shop = _shopApplication.GetDetails(id);
            var command = new Create_Sold
            {
                LocationName = _location_Application.GetDetails(shop.Location_Id).Name,
                ShopName = shop.Name,
                Shop_Id = id
            };
            return Partial("./Full", command);
        }
        public IActionResult OnPostFull(Create_Sold command)
        {
            _soldApplication.Create(command);
            return RedirectToPage("./Index");
        }
        public IActionResult OnGetEmpty(int id)
        {
            var shop = _shopApplication.GetDetails(id);
            var command = new Edit_Sold
            {
                LocationName = _location_Application.GetDetails(shop.Location_Id).Name,
                ShopName = shop.Name,
                Shop_Id = id,
                Id = shop.Id_Shopkeeper,
            };
            return Partial("./Empty", command);
        }
        public IActionResult OnPostEmpty(Edit_Sold command)
        {
            _soldApplication.Empty(command);
            return RedirectToPage("./Index");
        }
        public IActionResult OnGetTenants(int id)
        {
            var locationid = _shopApplication.GetDetails(id);
            var command = new Removed
            {
                Solds = _soldApplication.GetViewModel().Where(x => x.Status == true && x.Id_Shop == id).ToList(),
                Id = _shopApplication.GetDetails(id).Id_Shopkeeper,
                LocationName = _location_Application.GetDetails(locationid.Location_Id).Name,
                ShopName = _shopApplication.GetDetails(id).Name,
            };
            return Partial("./Tenants", command);
        }
    }
}