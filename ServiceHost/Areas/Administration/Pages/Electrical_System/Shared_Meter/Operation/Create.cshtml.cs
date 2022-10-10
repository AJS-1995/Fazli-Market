using AccountManagement.Application.Contracts.Electrical_System.Box_Meter;
using AccountManagement.Application.Contracts.Electrical_System.Shared_Meter;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Areas.Administration.Pages.Electrical_System.Shared_Meter.Operation
{
    public class CreateModel : PageModel
    {
        public string BoxName;
        public string Name;
        public int Id;
        public int Grade_Past;

        private readonly IShared_MeterApplication _sharedmeterApplication;
        private readonly IBoxMeterApplication _boxmeterApplication;
        private readonly IMSOperationApplication _msOperationApplication;
        public CreateModel(IShared_MeterApplication sharedmeterApplication, IBoxMeterApplication boxmeterApplication, IMSOperationApplication msOperationApplication)
        {
            _sharedmeterApplication = sharedmeterApplication;
            _boxmeterApplication = boxmeterApplication;
            _msOperationApplication = msOperationApplication;
        }

        public void OnGet(int id)
        {
            var meter = _sharedmeterApplication.GetDetails(id);
            BoxName = _boxmeterApplication.GetDetails(meter.BoxMeter_Id).Name;
            Name = meter.Name;
            Id = id;
            Grade_Past = (int)meter.Grade;
        }
        public RedirectToPageResult OnPost(MSOperationCreate command)
        {
            _msOperationApplication.Create(command);
            return RedirectToPage("./Index", new { id = command.Meter_Id });
        }
    }
}