using System.Collections.Generic;
using System.Linq;
using AccountManagement.Application.Contracts.Electrical_System.General_Meter;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Areas.Administration.Pages.Electrical_System.General_Meter
{
    public class IndexModel : PageModel
    {
        public List<GeneralMeterViewModel> GeneralMeters;
        private readonly IGeneralMeterApplication _generalMeterApplication;
        public IndexModel(IGeneralMeterApplication generalMeterApplication)
        {
            _generalMeterApplication = generalMeterApplication;
        }

        public void OnGet()
        {
            _generalMeterApplication.Total_Rest();
            GeneralMeters = _generalMeterApplication.GetGeneralMeter().Where(x => x.Status == true).ToList();
        }
        public IActionResult OnGetEdit(int id)
        {
            var result = _generalMeterApplication.GetDetails(id);
            return Partial("./Edit", result);
        }
        public IActionResult OnGetCreate()
        {
            return Partial("./Create");
        }
        public IActionResult OnPostCreate(GeneralMeterCreate command)
        {
            _generalMeterApplication.Create(command);
            return RedirectToPage("./Index");
        }
        public IActionResult OnPostEdit(GeneralMeterEdit command)
        {
            _generalMeterApplication.Edit(command);
            return RedirectToPage("./Index");
        }
        public IActionResult OnGetRemoved()
        {
            var command = new Removed()
            {
                generalMeters = _generalMeterApplication.GetGeneralMeter().Where(x => x.Status == false).ToList(),
            };
            return Partial("./Removed", command);
        }
        public RedirectToPageResult OnGetActivate(int id)
        {
            _generalMeterApplication.Activate(id);
            return RedirectToPage("./Index");
        }
        public RedirectToPageResult OnGetRemove(int id)
        {
            _generalMeterApplication.Remove(id);
            return RedirectToPage("./Index");
        }
    }
}