using AccountManagement.Application.Contracts.Electrical_System.Box_Meter;
using AccountManagement.Application.Contracts.Electrical_System.Shared_Meter;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ServiceHost.Areas.Administration.Pages.Electrical_System.Shared_Meter
{
    public class CreateModel : PageModel
    {
        public SelectList BoxMeters;

        private readonly IBoxMeterApplication _boxMeterApplication;
        private readonly IShared_MeterApplication _sharedmeterApplication;
        public CreateModel(IBoxMeterApplication boxMeterApplication, IShared_MeterApplication sharedmeterApplication)
        {
            _boxMeterApplication = boxMeterApplication;
            _sharedmeterApplication = sharedmeterApplication;
        }
        public void OnGet()
        {
            BoxMeters = new SelectList(_boxMeterApplication.GetViewModel(), "Id", "Name");
        }
        public RedirectToPageResult OnPost(Shared_MeterCreate command)
        {
            _sharedmeterApplication.Create(command);
            return RedirectToPage("./Create");
        }
    }
}