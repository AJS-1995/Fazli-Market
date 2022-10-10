using System.Linq;
using AccountManagement.Application.Contracts.Locations;
using AccountManagement.Application.Contracts.Money;
using AccountManagement.Application.Contracts.Rent;
using AccountManagement.Application.Contracts.Shop;
using AccountManagement.Application.Contracts.Shop_For_Rent;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ServiceHost.Areas.Administration.Pages.PeoplesAccounts.ShopkeeperAccounts.Rent
{
    public class CreateModel : PageModel
    {
        public int Id;
        public SelectList Moneys;
        public SelectList Shops;
        public SelectList Locations;
        public int ren = 1;
        public Edit_ShopForRent scommand;
        public Edit_Location lcommand;
        public MoneyEdit mcommand;
        public RentCreate command;
        private readonly IRentApplication _rentApplication;
        private readonly IMoneyApplication _moneyApplication;
        private readonly IShop_Application _shopApplication;
        private readonly IShop_For_RentApplication _shop_For_RentApplication;
        private readonly ILocation_Application _location_Application;
        public CreateModel(IMoneyApplication moneyApplication, IShop_Application shopApplication,
            IShop_For_RentApplication shop_For_RentApplication, ILocation_Application location_Application, IRentApplication rentApplication)
        {
            _moneyApplication = moneyApplication;
            _shopApplication = shopApplication;
            _shop_For_RentApplication = shop_For_RentApplication;
            _location_Application = location_Application;
            _rentApplication = rentApplication;
        }
        public void OnGet(int id)
        {
            Moneys = new SelectList(_moneyApplication.GetMoney().Where(x => x.Status == true), "Id", "Name");
            Locations = new SelectList(_location_Application.GetViewModel().Where(x => x.Status == true), "Id", "Name");
            scommand = _shop_For_RentApplication.GetDetails(id);

            var shopa = _shopApplication.GetDetails(scommand.Shop_Id);
            lcommand = _location_Application.GetDetails(shopa.Location_Id);
            mcommand = _moneyApplication.GetDetails(scommand.Money_Id);
            Shops = new SelectList(_shopApplication.GetLocations(lcommand.Id), "Id", "Name");
            Id = id;
        }
        public IActionResult OnGetLocation(int location)
        {
            var result = _shopApplication.GetLocations(location).Where(x => x.Rent == false);
            return new JsonResult(result);
        }
        public IActionResult OnPostCreate(RentEdit command)
        {
            command.Year = (int)command.Years;
            var forrent = _shop_For_RentApplication.GetDetails(command.ForRent_Id);
            var rent = _rentApplication.GetViewModel().Where(x => x.Status == true).ToList();
            foreach (var item in rent)
            {
                if (item.Shop_Id == command.Shop_Id && item.Money_Id == command.Money_Id && item.ForRent_Id == command.ForRent_Id && item.Year == command.Year)
                {
                    int id = item.Id;
                    var rent_id = _rentApplication.GetDetails(id);
                    switch (command.Month)
                    {
                        case 1:
                            ren = 0;
                            command.Id = id;
                            command.Month_1 = command.Rent;
                            _rentApplication.Month1(command);
                            break;
                        case 2:
                            ren = 0;
                            command.Id = id;
                            command.Month_2 = command.Rent;
                            _rentApplication.Month2(command);
                            break;
                        case 3:
                            ren = 0;
                            command.Id = id;
                            command.Month_3 = command.Rent;
                            _rentApplication.Month3(command);
                            break;
                        case 4:
                            ren = 0;
                            command.Id = id;
                            command.Month_4 = command.Rent;
                            _rentApplication.Month4(command);
                            break;
                        case 5:
                            ren = 0;
                            command.Id = id;
                            command.Month_5 = command.Rent;
                            _rentApplication.Month5(command);
                            break;
                        case 6:
                            ren = 0;
                            command.Id = id;
                            command.Month_6 = command.Rent;
                            _rentApplication.Month6(command);
                            break;
                        case 7:
                            ren = 0;
                            command.Id = id;
                            command.Month_7 = command.Rent;
                            _rentApplication.Month7(command);
                            break;
                        case 8:
                            ren = 0;
                            command.Id = id;
                            command.Month_8 = command.Rent;
                            _rentApplication.Month8(command);
                            break;
                        case 9:
                            ren = 0;
                            command.Id = id;
                            command.Month_9 = command.Rent;
                            _rentApplication.Month9(command);
                            break;
                        case 10:
                            ren = 0;
                            command.Id = id;
                            command.Month_10 = command.Rent;
                            _rentApplication.Month10(command);
                            break;
                        case 11:
                            ren = 0;
                            command.Id = id;
                            command.Month_11 = command.Rent;
                            _rentApplication.Month11(command);
                            break;
                        case 12:
                            ren = 0;
                            command.Id = id;
                            command.Month_12 = command.Rent;
                            _rentApplication.Month12(command);
                            break;
                    }
                }
            }
            if (ren == 1)
            {
                switch (command.Month)
                {
                    case 1:
                        command.Month_1 = command.Rent;
                        break;
                    case 2:
                        command.Month_2 = command.Rent;
                        break;
                    case 3:
                        command.Month_3 = command.Rent;
                        break;
                    case 4:
                        command.Month_4 = command.Rent;
                        break;
                    case 5:
                        command.Month_5 = command.Rent;
                        break;
                    case 6:
                        command.Month_6 = command.Rent;
                        break;
                    case 7:
                        command.Month_7 = command.Rent;
                        break;
                    case 8:
                        command.Month_8 = command.Rent;
                        break;
                    case 9:
                        command.Month_9 = command.Rent;
                        break;
                    case 10:
                        command.Month_10 = command.Rent;
                        break;
                    case 11:
                        command.Month_11 = command.Rent;
                        break;
                    case 12:
                        command.Month_12 = command.Rent;
                        break;
                }
                _rentApplication.Create(command);
            }
            return RedirectToPage("./Index", new { id = command.ForRent_Id });
        }
    }
}
