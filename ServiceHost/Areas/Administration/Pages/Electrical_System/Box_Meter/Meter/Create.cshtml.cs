using System.Linq;
using AccountManagement.Application.Contracts.Electrical_System.Box_Meter;
using AccountManagement.Application.Contracts.Electrical_System.Box_Meter.Meter;
using AccountManagement.Application.Contracts.Locations;
using AccountManagement.Application.Contracts.Shop;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ServiceHost.Areas.Administration.Pages.Electrical_System.Box_Meter.Meter
{
    public class CreateModel : PageModel
    {
        public SelectList BoxMeters;
        public SelectList Locations;
        public SelectList Shops;

        private readonly IBoxMeterApplication _boxMeterApplication;
        private readonly ILocation_Application _location_Application;
        private readonly IShop_Application _shopApplication;
        private readonly IMeterApplication _meterApplication;
        public CreateModel(IBoxMeterApplication boxMeterApplication, ILocation_Application location_Application, IShop_Application shopApplication, IMeterApplication meterApplication)
        {
            _boxMeterApplication = boxMeterApplication;
            _location_Application = location_Application;
            _shopApplication = shopApplication;
            _meterApplication = meterApplication;
        }

        public void OnGet()
        {
            BoxMeters = new SelectList(_boxMeterApplication.GetViewModel(), "Id", "Name");
            Locations = new SelectList(_location_Application.GetViewModel(), "Id", "Name");
        }
        public IActionResult OnGetLocation(int location)
        {
            var result = _shopApplication.GetLocations(location).Where(x => x.Meter == false);
            return new JsonResult(result);
        }
        public RedirectToPageResult OnPost(MeterCreate command)
        {
            _meterApplication.Create(command);
            return RedirectToPage("./Create");
        }
    }
}