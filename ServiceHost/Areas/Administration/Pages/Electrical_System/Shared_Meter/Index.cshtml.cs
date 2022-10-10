using System.Collections.Generic;
using System.Linq;
using AccountManagement.Application.Contracts.Electrical_System.Box_Meter;
using AccountManagement.Application.Contracts.Electrical_System.Shared_Meter;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Areas.Administration.Pages.Electrical_System.Shared_Meter
{
    public class IndexModel : PageModel
    {
        public List<Shared_MeterViewModel> Shared_Meters;
        private readonly IShared_MeterApplication _sharedmeterApplication;

        public IndexModel(IShared_MeterApplication sharedmeterApplication)
        {
            _sharedmeterApplication = sharedmeterApplication;
        }

        public void OnGet()
        {
            _sharedmeterApplication.Total_Rest();
            Shared_Meters = _sharedmeterApplication.GetViewModel().Where(x => x.Status == true).ToList();
        }
        public IActionResult OnGetRemoved()
        {
            var command = new MeterRemoved()
            {
                Shared_Meters = _sharedmeterApplication.GetViewModel().Where(x => x.Status == false).ToList(),
            };
            return Partial("./Removed", command);
        }
        public RedirectToPageResult OnGetRemove(int id)
        {
            _sharedmeterApplication.Remove(id);
            return RedirectToPage("./Index");
        }
        public RedirectToPageResult OnGetActivate(int id)
        {
            _sharedmeterApplication.Activate(id);
            return RedirectToPage("./Index");
        }
    }
}