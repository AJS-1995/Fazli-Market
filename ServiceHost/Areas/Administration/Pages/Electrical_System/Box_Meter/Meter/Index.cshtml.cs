using System.Collections.Generic;
using System.Linq;
using AccountManagement.Application.Contracts.Electrical_System.Box_Meter;
using AccountManagement.Application.Contracts.Electrical_System.Box_Meter.Meter;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Areas.Administration.Pages.Electrical_System.Box_Meter.Meter
{
    public class IndexModel : PageModel
    {
        public decimal Operation;
        public decimal Pay;
        public decimal Total;
        public List<MeterViewModel> Meters;
        private readonly IMeterApplication _meterApplication;
        private readonly IMOperationApplication _moperationApplication;
        private readonly IMPayApplication _mpayApplication;
        public IndexModel(IMeterApplication meterApplication, IMOperationApplication moperationApplication, IMPayApplication mpayApplication)
        {
            _meterApplication = meterApplication;
            _moperationApplication = moperationApplication;
            _mpayApplication = mpayApplication;
        }

        public void OnGet()
        {
            _meterApplication.Total_Rest();
            Operation = _moperationApplication.GetOperation().Where(x => x.Status == true).Sum(x => x.Rest);
            Pay = _mpayApplication.GetMPay().Where(x => x.Status == true).Sum(x => x.Amount);
            Total = Pay - Operation;
            Meters = _meterApplication.GetViewModel().Where(x => x.Status == true).ToList();
        }
        public IActionResult OnGetRemoved()
        {
            var command = new MeterRemoved()
            {
                Meters = _meterApplication.GetViewModel().Where(x => x.Status == false).ToList(),
            };
            return Partial("./Removed", command);
        }
        public RedirectToPageResult OnGetRemove(int id)
        {
            _meterApplication.Remove(id);
            return RedirectToPage("./Index");
        }
        public RedirectToPageResult OnGetActivate(int id)
        {
            _meterApplication.Activate(id);
            return RedirectToPage("./Index");
        }
    }
}