using System.Collections.Generic;
using System.Linq;
using AccountManagement.Application.Contracts.Locations;
using AccountManagement.Application.Contracts.Shop;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Areas.Administration.Pages.Market.Locations
{
    public class IndexModel : PageModel
    {
        public List<ViewModel_Location> Locations;
        public List<ViewModel_Shop> shops;
        private readonly ILocation_Application _location_Application;
        private readonly IShop_Application _shopApplication;
        public IndexModel(ILocation_Application location_Application, IShop_Application shopApplication)
        {
            _location_Application = location_Application;
            _shopApplication = shopApplication;
        }
        public void OnGet()
        {
            Locations = _location_Application.GetViewModel().Where(x => x.Status == true).ToList();
            shops = _shopApplication.GetShop().Where(x => x.Status == true).ToList();
        }
        public IActionResult OnGetCreate(Create_Location command)
        {
            return Partial("./Create", command);
        }
        public IActionResult OnPostCreate(Create_Location command)
        {
            _location_Application.Create(command);
            return RedirectToPage("./Index");
        }
        public IActionResult OnGetEdit(int id)
        {
            var result = _location_Application.GetDetails(id);
            return Partial("./Edit", result);
        }
        public IActionResult OnPostEdit(Edit_Location command)
        {
            _location_Application.Edit(command);
            return RedirectToPage("./Index");
        }
        public IActionResult OnGetRemoved()
        {
            var commnd = new Removed_Location()
            {
                Locations = _location_Application.GetViewModel().Where(x => x.Status == false).ToList(),
                Shops = _shopApplication.GetShop().Where(x => x.Status == true).ToList(),
            };
            return Partial("./Removed", commnd);
        }
        public RedirectToPageResult OnGetActivate(int id)
        {
            _location_Application.Activate(id);
            return RedirectToPage("./Index");
        }
        public RedirectToPageResult OnGetRemove(int id)
        {
            _location_Application.Remove(id);
            return RedirectToPage("./Index");
        }
    }
}