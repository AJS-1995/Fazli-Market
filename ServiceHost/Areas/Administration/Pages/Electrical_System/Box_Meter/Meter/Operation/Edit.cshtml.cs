using AccountManagement.Application.Contracts.Electrical_System.Box_Meter;
using AccountManagement.Application.Contracts.Electrical_System.Box_Meter.Meter;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Areas.Administration.Pages.Electrical_System.Box_Meter.Meter.Operation
{
    public class EditModel : PageModel
    {
        public BoxMeterEdit bcommand;
        public MOperationEdit command;
        public MeterEdit mcommand;
        public int Id;

        private readonly IMeterApplication _meterApplication;
        private readonly IBoxMeterApplication _boxmeterApplication;
        private readonly IMOperationApplication _mOperationApplication;
        public EditModel(IMOperationApplication mOperationApplication, IMeterApplication meterApplication, IBoxMeterApplication boxmeterApplication)
        {
            _mOperationApplication = mOperationApplication;
            _meterApplication = meterApplication;
            _boxmeterApplication = boxmeterApplication;
        }

        public void OnGet(int id)
        {
            command = _mOperationApplication.GetDetails(id);
            var meter = _meterApplication.GetDetails(command.Meter_Id);
            bcommand = _boxmeterApplication.GetDetails(meter.BoxMeter_Id);
            mcommand = _meterApplication.GetDetails(meter.Id);
            Id = id;
        }
        public RedirectToPageResult OnPost(MOperationEdit command)
        {
            var Succedded = _mOperationApplication.Edit(command);
            if (Succedded.IsSuccedded)
            {
                return RedirectToPage("./Print", command);
            }
            else
            {
                return RedirectToPage(Id);
            }
        }
    }
}