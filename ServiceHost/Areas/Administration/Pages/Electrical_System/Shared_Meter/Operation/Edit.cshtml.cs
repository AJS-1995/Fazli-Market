using AccountManagement.Application.Contracts.Electrical_System.Box_Meter;
using AccountManagement.Application.Contracts.Electrical_System.Shared_Meter;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Areas.Administration.Pages.Electrical_System.Shared_Meter.Operation
{
    public class EditModel : PageModel
    {
        public BoxMeterEdit bcommand;
        public MSOperationEdit command;
        public Shared_MeterEdit mcommand;

        private readonly IShared_MeterApplication _sharedmeterApplication;
        private readonly IBoxMeterApplication _boxmeterApplication;
        private readonly IMSOperationApplication _mSOperationApplication;
        public EditModel(IMSOperationApplication mSOperationApplication, IShared_MeterApplication sharedmeterApplication, IBoxMeterApplication boxmeterApplication)
        {
            _mSOperationApplication = mSOperationApplication;
            _sharedmeterApplication = sharedmeterApplication;
            _boxmeterApplication = boxmeterApplication;
        }

        public void OnGet(int id)
        {
            command = _mSOperationApplication.GetDetails(id);
            var meter = _sharedmeterApplication.GetDetails(command.Meter_Id);
            bcommand = _boxmeterApplication.GetDetails(meter.BoxMeter_Id);
            mcommand = _sharedmeterApplication.GetDetails(meter.Id);
        }
        public RedirectToPageResult OnPost(MSOperationEdit command)
        {
            _mSOperationApplication.Edit(command);
            return RedirectToPage("./Index", new { id = command.Meter_Id });
        }
    }
}