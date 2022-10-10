using System.Collections.Generic;
using System.Linq;
using AccountManagement.Application.Contracts.Locations;
using AccountManagement.Application.Contracts.Shop;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Areas.Administration.Pages.Book.Shops
{
    public class IndexModel : PageModel
    {
        public List<ViewModel_Shop> shops;

        private readonly IShop_Application _shopApplication;
        private readonly ILocation_Application _locationApplication;
        public IndexModel(IShop_Application shopApplication, ILocation_Application locationApplication)
        {
            _shopApplication = shopApplication;
            _locationApplication = locationApplication;
        }
        public void OnGet()
        {
            shops = _shopApplication.GetShop().Where(x => x.Status == true).ToList();
        }
        public IActionResult OnGetCreate(Create_Shop command)
        {
            command.Locations = _locationApplication.GetViewModel().Where(x => x.Status == true).ToList();
            return Partial("./Create", command);
        }
        public IActionResult OnPostCreate(Create_Shop command)
        {
            _shopApplication.Create(command);
            return RedirectToPage("./Index");
        }
        public IActionResult OnGetEdit(int id)
        {
            var result = _shopApplication.GetDetails(id);
            result.Locations = _locationApplication.GetViewModel().Where(x => x.Status == true).ToList();
            result.Location = _locationApplication.GetDetails(result.Location_Id).Name;
            return Partial("Edit", result);
        }
        public IActionResult OnPostEdit(Edit_Shop command)
        {
            _shopApplication.Edit(command);
            return RedirectToPage("./Index");
        }
        public IActionResult OnGetRemoved()
        {
            var commnd = new Removed_Location()
            {
                Shops = _shopApplication.GetShop().Where(x => x.Status == false).ToList(),
            };
            return Partial("./Removed", commnd);
        }
        public RedirectToPageResult OnGetActivate(int id)
        {
            _shopApplication.Activate(id);
            return RedirectToPage("./Index");
        }
        public RedirectToPageResult OnGetRemove(int id)
        {
            _shopApplication.Remove(id);
            return RedirectToPage("./Index");
        }
        public RedirectToPageResult OnGetSold(int id)
        {
            _shopApplication.ShopSold(id);
            return RedirectToPage("./Index");
        }
        public RedirectToPageResult OnGetRent(int id)
        {
            _shopApplication.ShopRent(id);
            return RedirectToPage("./Index");
        }
    }
}