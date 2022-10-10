using System.Collections.Generic;
using System.Linq;
using AccountManagement.Application.Contracts.Money;
using AccountManagement.Application.Contracts.Shop;
using AccountManagement.Application.Contracts.Shop_For_Rent;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Areas.Administration.Pages.Accounts.ShopAccounts
{
    public class IndexModel : PageModel
    {
        public List<ViewModel_Shop> AccountRents;
        public List<ViewModel_ShopForRent> AccountRests;
        public List<MoneyViewModel> Moneys;

        private readonly IShop_Application _shopApplication;
        private readonly IShop_For_RentApplication _shop_For_RentApplication;
        private readonly IMoneyApplication _moneyApplication;

        public IndexModel(IShop_Application shopApplication, IShop_For_RentApplication shop_For_RentApplication, IMoneyApplication moneyApplication)
        {
            _shopApplication = shopApplication;
            _shop_For_RentApplication = shop_For_RentApplication;
            _moneyApplication = moneyApplication;
        }

        public void OnGet()
        {
            AccountRests = _shop_For_RentApplication.GetViewModel().Where(x => x.Status == true).ToList();
            AccountRents = _shopApplication.GetShop().Where(x => x.Status == true && x.Rent == true && x.Sold == false).ToList();
            Moneys = _moneyApplication.GetMoney().Where(x => x.Status == true).ToList();
        }
    }
}