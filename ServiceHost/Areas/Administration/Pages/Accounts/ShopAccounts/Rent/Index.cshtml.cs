using System.Collections.Generic;
using System.Linq;
using AccountManagement.Application.Contracts.Locations;
using AccountManagement.Application.Contracts.Money;
using AccountManagement.Application.Contracts.Rent;
using AccountManagement.Application.Contracts.Shop;
using AccountManagement.Application.Contracts.Shop_For_Rent;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Areas.Administration.Pages.Accounts.ShopAccounts.Rent
{
    public class IndexModel : PageModel
    {
        public List<RentViewModel> Rent;
        public string Location;
        public string Name;
        public int Id;
        public int ren = 1;
        private readonly IRentApplication _rentApplication;
        private readonly IShop_For_RentApplication _shop_For_RentApplication;
        private readonly IShop_Application _shop_Application;
        private readonly ILocation_Application _location_Application;
        private readonly IMoneyApplication _moneyApplication;
        public IndexModel(IRentApplication rentApplication, IShop_For_RentApplication shop_For_RentApplication, IShop_Application shop_Application, ILocation_Application location_Application, IMoneyApplication moneyApplication)
        {
            _rentApplication = rentApplication;
            _shop_For_RentApplication = shop_For_RentApplication;
            _shop_Application = shop_Application;
            _location_Application = location_Application;
            _moneyApplication = moneyApplication;
        }

        public void OnGet(int id)
        {
            _shop_Application.Rest();
            Rent = _rentApplication.GetViewModel().Where(x => x.Status == true && x.Shop_Id == id).ToList();
            Location = _rentApplication.GetViewModel().Where(x => x.Shop_Id == id).Select(x => x.Location).FirstOrDefault();
            Name = _rentApplication.GetViewModel().Where(x => x.Shop_Id == id).Select(x => x.Shop).FirstOrDefault();
            Id = id;
        }
        public IActionResult OnGetRemoved(int id)
        {
            var commnd = new Removed()
            {
                Rents = _rentApplication.GetViewModel().Where(x => x.Status == false && x.Shop_Id == id).ToList(),
                Id = id,
            };
            Id = id;
            return Partial("./Removed", commnd);
        }
        public IActionResult OnGetActivate(int id)
        {
            _rentApplication.Activate(id);
            var result = _rentApplication.GetDetails(id);
            return RedirectToPage("./Index", new { id = result.Shop_Id });
        }
        public IActionResult OnGetRemove(int id)
        {
            _rentApplication.Remove(id);
            var result = _rentApplication.GetDetails(id);
            return RedirectToPage("./Index", new { id = result.Shop_Id });
        }
        public IActionResult OnGetEdit(int id)
        {
            var result = _rentApplication.GetDetails(id);
            var Shop = _rentApplication.GetDetails(id).Shop_Id;
            int location = _shop_Application.GetDetails(Shop).Location_Id;
            int forrent = _shop_Application.GetDetails(Shop).Id_Shopkeeper;
            int money = _shop_For_RentApplication.GetDetails(forrent).Money_Id;
            result.Shop_Id = Shop;
            result.Location = _location_Application.GetDetails(location).Name;
            result.Shop = _shop_Application.GetDetails(Shop).Name;
            result.ForRent_Id = forrent;
            result.ForRentName = _shop_For_RentApplication.GetDetails(forrent).Name;
            result.ForRentCompany = _shop_For_RentApplication.GetDetails(forrent).Company;
            result.Rent = _shop_For_RentApplication.GetDetails(forrent).Rent;
            result.Money_Id = money;
            result.Money = _moneyApplication.GetDetails(money).Name;
            return Partial("./Edit", result);
        }
        public IActionResult OnPostEdit(RentEdit command)
        {
            _rentApplication.Edit(command);
            return RedirectToPage("./Index", new { id = command.Shop_Id });
        }
        public IActionResult OnGetCreate(int id)
        {
            int location = _shop_Application.GetDetails(id).Location_Id;
            int forrent = _shop_Application.GetDetails(id).Id_Shopkeeper;
            int money = _shop_For_RentApplication.GetDetails(forrent).Money_Id;
            var commnd = new RentCreate()
            {
                Shop_Id = id,
                Location = _location_Application.GetDetails(location).Name,
                Shop = _shop_Application.GetDetails(id).Name,
                ForRent_Id = forrent,
                ForRentName = _shop_For_RentApplication.GetDetails(forrent).Name,
                ForRentCompany = _shop_For_RentApplication.GetDetails(forrent).Company,
                Rent = _shop_For_RentApplication.GetDetails(forrent).Rent,
                Money_Id = money,
                Money = _moneyApplication.GetDetails(money).Name
            };
            return Partial("./Create", commnd);
        }
        public IActionResult OnPostCreate(RentEdit command)
        {
            command.Year = (int)command.Years;
            var forrent = _shop_Application.GetDetails(command.Shop_Id);
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
            return RedirectToPage("./Index", new { id = command.Shop_Id });
        }
    }
}