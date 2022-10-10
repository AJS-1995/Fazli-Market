using System.Collections.Generic;
using System.Linq;
using AccountManagement.Application.Contracts.Locations;
using AccountManagement.Application.Contracts.Shop_For_Rent;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Areas.Administration.Pages.People.ShopForRent
{
    public class IndexModel : PageModel
    {
        public List<ViewModel_ShopForRent> Shop_For_Rent;
        public List<ViewModel_Location> Locations;

        private readonly IShop_For_RentApplication _shop_For_RentApplication;

        public IndexModel(IShop_For_RentApplication shop_For_RentApplication)
        {
            _shop_For_RentApplication = shop_For_RentApplication;
        }

        public void OnGet()
        {
            Shop_For_Rent = _shop_For_RentApplication.GetViewModel().Where(x => x.Status == true).ToList();
        }
        public IActionResult OnGetRemoved()
        {
            var commnd = new Removed()
            {
                ShopForRents = _shop_For_RentApplication.GetViewModel().Where(x => x.Status == false).ToList(),
            };
            return Partial("./Removed", commnd);
        }
        public RedirectToPageResult OnGetActivate(int id)
        {
            _shop_For_RentApplication.Activate(id);
            return RedirectToPage("./Index");
        }
        public RedirectToPageResult OnGetRemove(int id)
        {
            _shop_For_RentApplication.Remove(id);
            return RedirectToPage("./Index");
        }
        public IActionResult OnGetDetails(int id)
        {
            var account = _shop_For_RentApplication.GetDetails(id);
            account.ShopName = _shop_For_RentApplication.GetViewModel().Where(x => x.Id == id).FirstOrDefault().Shop;
            account.LocationName = _shop_For_RentApplication.GetViewModel().Where(x => x.Id == id).FirstOrDefault().Location;
            account.Money = _shop_For_RentApplication.GetViewModel().Where(x => x.Id == id).FirstOrDefault().Money;
            return Partial("Details", account);
        }
    }
}