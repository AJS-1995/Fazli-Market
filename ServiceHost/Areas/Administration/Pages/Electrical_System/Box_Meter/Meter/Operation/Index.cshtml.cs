using System.Collections.Generic;
using System.Linq;
using AccountManagement.Application.Contracts.Electrical_System.Box_Meter;
using AccountManagement.Application.Contracts.Electrical_System.Box_Meter.Meter;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Areas.Administration.Pages.Electrical_System.Box_Meter.Meter.Operation
{
    public class IndexModel : PageModel
    {
        public List<MOperationViewModel> MOperations;
        public string Name;
        public string Cod;
        public int Id;
        private readonly IMOperationApplication _moperationApplication;
        private readonly IMeterApplication _meterApplication;

        public IndexModel(IMOperationApplication moperationApplication, IMeterApplication meterApplication)
        {
            _moperationApplication = moperationApplication;
            _meterApplication = meterApplication;
        }

        public void OnGet(int id)
        {
            MOperations = _moperationApplication.GetOperation().Where(x => x.Status == true && x.Meter_Id == id).ToList();
            var mOperation = _moperationApplication.GetDetails(id);
            Name = _meterApplication.GetDetails(id).Name;
            Cod = _meterApplication.GetDetails(id).Cod;
            Id = id;
        }
        public IActionResult OnGetRemoved(int id)
        {
            var command = new MeterRemoved()
            {
                MOperations = _moperationApplication.GetOperation().Where(x => x.Status == false && x.Meter_Id == id).ToList(),
                Id = id,
            };
            return Partial("./Removed", command);
        }
        public RedirectToPageResult OnGetRemove(int id)
        {
            var mOperation = _moperationApplication.GetDetails(id);
            _moperationApplication.Remove(id);
            return RedirectToPage("./Index", new { id = mOperation.Meter_Id });
        }
        public RedirectToPageResult OnGetActivate(int id)
        {
            var mOperation = _moperationApplication.GetDetails(id);
            _moperationApplication.Activate(id);
            return RedirectToPage("./Index", new { id = mOperation.Meter_Id });
        }
    }
}