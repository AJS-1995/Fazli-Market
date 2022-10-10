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
    public class EditModel : PageModel
    {
        public SelectList Shops;
        public SelectList Locations;

        public Edit_Sold command;
        public Edit_Location lcommand;

        private readonly IShop_Application _shopApplication;
        private readonly ISoldApplication _soldApplication;
        private readonly ILocation_Application _location_Application;
        public EditModel(IShop_Application shopApplication, ISoldApplication soldApplication, ILocation_Application location_Application)
        {
            _shopApplication = shopApplication;
            _soldApplication = soldApplication;
            _location_Application = location_Application;
        }
        public void OnGet(int id)
        {
            var shop = _shopApplication.GetShop();
            if (shop.Count != 0)
            {
                Locations = new SelectList(_location_Application.GetViewModel(), "Id", "Name");
                command = _soldApplication.GetDetails(id);

                var shopa = _shopApplication.GetDetails(command.Shop_Id);
                lcommand = _location_Application.GetDetails(shopa.Location_Id);
                Shops = new SelectList(_shopApplication.GetLocations(lcommand.Id), "Id", "Name");
            }
        }
        public RedirectToPageResult OnPost(Edit_Sold command)
        {
            _soldApplication.Edit(command);
            return RedirectToPage("./Index");
        }
    }
}