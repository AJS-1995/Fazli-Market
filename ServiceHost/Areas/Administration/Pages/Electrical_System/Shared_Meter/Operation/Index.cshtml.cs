using System.Collections.Generic;
using System.Linq;
using AccountManagement.Application.Contracts.Electrical_System.Box_Meter;
using AccountManagement.Application.Contracts.Electrical_System.Shared_Meter;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Areas.Administration.Pages.Electrical_System.Shared_Meter.Operation
{
    public class IndexModel : PageModel
    {
        public List<MSOperationViewModel> MSOperations;
        public string Name;
        public int Id;
        private readonly IMSOperationApplication _msoperationApplication;
        private readonly IShared_MeterApplication _sharedmeterApplication;

        public IndexModel(IMSOperationApplication msoperationApplication, IShared_MeterApplication sharedmeterApplication)
        {
            _msoperationApplication = msoperationApplication;
            _sharedmeterApplication = sharedmeterApplication;
        }

        public void OnGet(int id)
        {
            MSOperations = _msoperationApplication.GetOperation().Where(x => x.Status == true && x.Meter_Id == id).ToList();
            var mOperation = _msoperationApplication.GetDetails(id);
            Name = _sharedmeterApplication.GetDetails(id).Name;
            Id = id;
        }
        public IActionResult OnGetRemoved(int id)
        {
            var command = new MeterRemoved()
            {
                MSOperations = _msoperationApplication.GetOperation().Where(x => x.Status == false && x.Meter_Id == id).ToList(),
                Id = id,
            };
            return Partial("./Removed", command);
        }
        public RedirectToPageResult OnGetRemove(int id)
        {
            var mOperation = _msoperationApplication.GetDetails(id);
            _msoperationApplication.Remove(id);
            return RedirectToPage("./Index", new { id = mOperation.Meter_Id });
        }
        public RedirectToPageResult OnGetActivate(int id)
        {
            var mOperation = _msoperationApplication.GetDetails(id);
            _msoperationApplication.Activate(id);
            return RedirectToPage("./Index", new { id = mOperation.Meter_Id });
        }
    }
}