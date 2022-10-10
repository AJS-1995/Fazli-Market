using AccountManagement.Application.Contracts.Electrical_System.Box_Meter;
using AccountManagement.Application.Contracts.Electrical_System.Shared_Meter;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ServiceHost.Areas.Administration.Pages.Electrical_System.Shared_Meter
{
    public class EditModel : PageModel
    {
        public SelectList BoxMeters;
        public Shared_MeterEdit command;

        private readonly IBoxMeterApplication _boxMeterApplication;
        private readonly IShared_MeterApplication _sharedmeterApplication;
        public EditModel(IBoxMeterApplication boxMeterApplication, IShared_MeterApplication sharedmeterApplication)
        {
            _boxMeterApplication = boxMeterApplication;
            _sharedmeterApplication = sharedmeterApplication;
        }

        public void OnGet(int id)
        {
            command = _sharedmeterApplication.GetDetails(id);
            BoxMeters = new SelectList(_boxMeterApplication.GetViewModel(), "Id", "Name");
        }
        public RedirectToPageResult OnPost(Shared_MeterEdit command)
        {
            _sharedmeterApplication.Edit(command);
            return RedirectToPage("./Index");
        }
    }
}