using System.Collections.Generic;
using System.Linq;
using AccountManagement.Application.Contracts.Electrical_System.Box_Meter;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Areas.Administration.Pages.Electrical_System.Box_Meter
{
    public class IndexModel : PageModel
    {
        public List<BoxMeterViewModel> BoxMeters;
        private readonly IBoxMeterApplication _boxMeterApplication;
        public IndexModel(IBoxMeterApplication boxMeterApplication)
        {
            _boxMeterApplication = boxMeterApplication;
        }

        public void OnGet()
        {
            BoxMeters = _boxMeterApplication.GetViewModel().Where(x => x.Status == true).ToList();
        }
        public IActionResult OnGetEdit(int id)
        {
            var result = _boxMeterApplication.GetDetails(id);
            return Partial("./Edit", result);
        }
        public IActionResult OnGetCreate()
        {
            return Partial("./Create");
        }
        public IActionResult OnPostCreate(BoxMeterCreate command)
        {
            _boxMeterApplication.Create(command);
            return RedirectToPage("./Index");
        }
        public IActionResult OnPostEdit(BoxMeterEdit command)
        {
            _boxMeterApplication.Edit(command);
            return RedirectToPage("./Index");
        }
        public IActionResult OnGetRemoved()
        {
            var command = new MeterRemoved()
            {
                BoxMeters = _boxMeterApplication.GetViewModel().Where(x => x.Status == false).ToList(),
            };
            return Partial("./Removed", command);
        }
        public RedirectToPageResult OnGetRemove(int id)
        {
            _boxMeterApplication.Remove(id);
            return RedirectToPage("./Index");
        }
        public RedirectToPageResult OnGetActivate(int id)
        {
            _boxMeterApplication.Activate(id);
            return RedirectToPage("./Index");
        }
    }
}