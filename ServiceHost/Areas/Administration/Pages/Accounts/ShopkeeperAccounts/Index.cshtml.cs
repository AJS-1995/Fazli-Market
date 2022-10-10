using System.Collections.Generic;
using System.Linq;
using AccountManagement.Application.Contracts.Shop_For_Rent;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Areas.Administration.Pages.PeoplesAccounts.ShopkeeperAccounts
{
    public class IndexModel : PageModel
    {
        public List<ViewModel_ShopForRent> ShopForRents;
        private readonly IShop_For_RentApplication _shop_For_RentApplication;

        public IndexModel(IShop_For_RentApplication shop_For_RentApplication)
        {
            _shop_For_RentApplication = shop_For_RentApplication;
        }

        public void OnGet()
        {
            _shop_For_RentApplication.Total_Rest();
            ShopForRents = _shop_For_RentApplication.GetViewModel().Where(x => x.Status == true).ToList();
        }
    }
}