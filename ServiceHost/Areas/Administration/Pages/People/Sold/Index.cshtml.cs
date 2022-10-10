using System.Collections.Generic;
using System.Linq;
using AccountManagement.Application.Contracts.Locations;
using AccountManagement.Application.Contracts.Sold;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Areas.Administration.Pages.People.Sold
{
    public class IndexModel : PageModel
    {
        public List<ViewModel_Sold> Sold;
        public List<ViewModel_Location> Locations;

        private readonly ISoldApplication _soldApplication;

        public IndexModel(ISoldApplication soldApplication)
        {
            _soldApplication = soldApplication;
        }

        public void OnGet()
        {
            Sold = _soldApplication.GetViewModel().Where(x => x.Status == true).ToList();
        }
        public IActionResult OnGetRemoved()
        {
            var commnd = new Removed()
            {
                Solds = _soldApplication.GetViewModel().Where(x => x.Status == false).ToList(),
            };
            return Partial("./Removed", commnd);
        }
        public RedirectToPageResult OnGetActivate(int id)
        {
            _soldApplication.Activate(id);
            return RedirectToPage("./Index");
        }
        public RedirectToPageResult OnGetRemove(int id)
        {
            _soldApplication.Remove(id);
            return RedirectToPage("./Index");
        }
        public IActionResult OnGetDetails(int id)
        {
            var account = _soldApplication.GetDetails(id);
            account.ShopName = _soldApplication.GetViewModel().Where(x => x.Id == id).FirstOrDefault().Shop;
            account.LocationName = _soldApplication.GetViewModel().Where(x => x.Id == id).FirstOrDefault().Location;
            return Partial("Details", account);
        }
    }
}