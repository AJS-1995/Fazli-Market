using _0_Framework.Application;
using AccountManagement.Application.Contracts.Electrical_System.Box_Meter;
using AccountManagement.Application.Contracts.Electrical_System.Box_Meter.Meter;
using AccountManagement.Application.Contracts.Electrical_System.Shared_Meter;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Linq;

namespace ServiceHost.Areas.Administration.Pages.Electrical_System.Box_Meter.Meter.Operation
{
    public class CreateModel : PageModel
    {
        public string BoxName;
        public string Name;
        public string Cod;
        public int Id;
        public int Grade_Past;

        private readonly IMeterApplication _meterApplication;
        private readonly IBoxMeterApplication _boxmeterApplication;
        private readonly IMOperationApplication _mOperationApplication;
        private readonly IMSOperationApplication _msOperationApplication;
        public CreateModel(IMeterApplication meterApplication, IBoxMeterApplication boxmeterApplication,
            IMOperationApplication mOperationApplication, IMSOperationApplication msOperationApplication)
        {
            _meterApplication = meterApplication;
            _boxmeterApplication = boxmeterApplication;
            _mOperationApplication = mOperationApplication;
            _msOperationApplication = msOperationApplication;
        }

        public void OnGet(int id)
        {
            var meter = _meterApplication.GetDetails(id);
            BoxName = _boxmeterApplication.GetDetails(meter.BoxMeter_Id).Name;
            Name = meter.Name;
            Cod = meter.Cod;
            Id = id;
            Grade_Past = (int)meter.Grade;
        }
        public IActionResult OnGetOther(string date_Rrad, string date_Pay)
        {
            decimal msop = _msOperationApplication.GetOperation().Where(x => x.Status == true && x.Date_Rrad == date_Rrad && x.Date_Pay == date_Pay).Sum(x => x.Total);
            var meter = _meterApplication.GetViewModel().Where(x => x.Status == true && x.Use == true);
            int result = Convert.ToInt32(msop / meter.Count());
            return new JsonResult(result);
        }
        public IActionResult OnPost(MOperationCreate command)
        {
            var Succedded = _mOperationApplication.Create(command);
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