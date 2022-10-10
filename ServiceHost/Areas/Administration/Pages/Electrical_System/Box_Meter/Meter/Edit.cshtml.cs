using AccountManagement.Application.Contracts.Electrical_System.Box_Meter;
using AccountManagement.Application.Contracts.Electrical_System.Box_Meter.Meter;
using AccountManagement.Application.Contracts.Locations;
using AccountManagement.Application.Contracts.Shop;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ServiceHost.Areas.Administration.Pages.Electrical_System.Box_Meter.Meter
{
    public class EditModel : PageModel
    {
        public SelectList BoxMeters;
        public SelectList Locations;
        public SelectList Shops;

        public MeterEdit command;
        public Edit_Location lcommand;

        private readonly IBoxMeterApplication _boxMeterApplication;
        private readonly ILocation_Application _location_Application;
        private readonly IMeterApplication _meterApplication;
        private readonly IShop_Application _shopApplication;
        public EditModel(IBoxMeterApplication boxMeterApplication, ILocation_Application location_Application, IMeterApplication meterApplication, IShop_Application shopApplication)
        {
            _boxMeterApplication = boxMeterApplication;
            _location_Application = location_Application;
            _meterApplication = meterApplication;
            _shopApplication = shopApplication;
        }

        public void OnGet(int id)
        {
            command = _meterApplication.GetDetails(id);
            BoxMeters = new SelectList(_boxMeterApplication.GetViewModel(), "Id", "Name");
            Locations = new SelectList(_location_Application.GetViewModel(), "Id", "Name");

            var shopa = _shopApplication.GetDetails(command.Shop_Id);
            lcommand = _location_Application.GetDetails(shopa.Location_Id);
            Shops = new SelectList(_shopApplication.GetShop(), "Id", "Name");
        }
        public RedirectToPageResult OnPost(MeterEdit command)
        {
            _meterApplication.Edit(command);
            return RedirectToPage("./Index");
        }
    }
}