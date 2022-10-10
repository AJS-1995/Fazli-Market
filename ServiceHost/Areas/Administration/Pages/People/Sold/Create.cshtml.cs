using System.Linq;
using AccountManagement.Application.Contracts.Locations;
using AccountManagement.Application.Contracts.Shop;
using AccountManagement.Application.Contracts.Sold;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ServiceHost.Areas.Administration.Pages.People.Sold
{
    [Authorize(Roles = "1 , 2")]
    public class CreateModel : PageModel
    {
        public SelectList Shops;
        public SelectList Locations;
        private readonly IShop_Application _shopApplication;
        private readonly ISoldApplication _soldApplication;
        private readonly ILocation_Application _location_Application;
        public CreateModel(IShop_Application shopApplication, ISoldApplication soldApplication, ILocation_Application location_Application)
        {
            _shopApplication = shopApplication;
            _soldApplication = soldApplication;
            _location_Application = location_Application;
        }
        public void OnGet()
        {
            var shop = _shopApplication.GetShop();
            if (shop.Count != 0)
            {
                Locations = new SelectList(_location_Application.GetViewModel(), "Id", "Name");
            }
        }
        public IActionResult OnGetLocation(int location)
        {
            var result = _shopApplication.GetLocations(location).Where(x => x.Sold == true && x.Rent == false);
            return new JsonResult(result);
        }
        public IActionResult OnPost(Create_Sold command)
        {
            _soldApplication.Create(command);
            return RedirectToPage("./Create");
        }
    }
}