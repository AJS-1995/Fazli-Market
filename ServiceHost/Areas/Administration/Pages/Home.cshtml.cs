using System.Collections.Generic;
using System.Linq;
using _01_Fazli_MarketQuery.Contracts.PayBoxs;
using AccountManagement.Application.Contracts.Electrical_System.Box_Meter.Meter;
using AccountManagement.Application.Contracts.Employee;
using AccountManagement.Application.Contracts.PayBox;
using AccountManagement.Application.Contracts.Person;
using AccountManagement.Application.Contracts.Shop;
using AccountManagement.Application.Contracts.Shop_For_Rent;
using AccountManagement.Application.Contracts.Sold;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Areas.Administration.Pages
{
    public class HomeModel : PageModel
    {
        public List<ViewModel_Shop> shops;
        public List<ViewModel_Shop> shopsSold;
        public List<ViewModel_Shop> shopsFull;
        public List<ViewModel_Shop> shopsEmpty;
        public List<ViewModel_ShopForRent> AccountRests;
        public List<ViewModel_PayBox> payboxs;
        public List<MeterViewModel> meters;
        public List<EmployeeViewModel> employees;
        public List<PersonViewModel> persons;
        public List<ViewModel_ShopForRent> forrents;
        public List<ViewModel_Sold> solds;

        public int countshops = 0;
        public int countshopssold = 0;
        public string countshopssolds;
        public int countshopsfull = 0;
        public string countshopsfulls;
        public int countshopsempty = 0;
        public string countshopsemptys;

        public decimal payboxsRest;
        public decimal AccountRest;
        public decimal metersRest;
        public decimal personsRest;
        public decimal employeesRest;

        private readonly IShop_Application _shopApplication;
        private readonly IShop_For_RentApplication _shop_For_RentApplication;
        private readonly IPayBoxApplication _payBoxApplication;
        private readonly IPersonApplication _personApplication;
        private readonly IEmployeeApplication _employeeApplication;
        private readonly IPayBox _payBox;
        private readonly IMeterApplication _meterApplication;
        private readonly ISoldApplication _soldApplication;
        public HomeModel(IShop_Application shopApplication, IShop_For_RentApplication shop_For_RentApplication,
            IPayBox payBox, IPayBoxApplication payBoxApplication, IPersonApplication personApplication,
            IEmployeeApplication employeeApplication, IMeterApplication meterApplication, ISoldApplication soldApplication)
        {
            _shopApplication = shopApplication;
            _shop_For_RentApplication = shop_For_RentApplication;
            _payBox = payBox;
            _payBoxApplication = payBoxApplication;
            _personApplication = personApplication;
            _employeeApplication = employeeApplication;
            _meterApplication = meterApplication;
            _soldApplication = soldApplication;
        }
        public void OnGet()
        {
            _shopApplication.Rest();
            _payBox.Total_PayBox();
            _shop_For_RentApplication.Total_Rest();
            _personApplication.Total_Rest();
            _employeeApplication.Total_Rest();
            _meterApplication.Total_Rest();

            shops = _shopApplication.GetShop().Where(x => x.Status == true).ToList();
            shopsSold = _shopApplication.GetShop().Where(x => x.Status == true && x.Sold == true).ToList();
            shopsFull = _shopApplication.GetShop().Where(x => x.Status == true && x.Sold == false && x.Rent == true).ToList();
            shopsEmpty = _shopApplication.GetShop().Where(x => x.Status == true && x.Sold == false && x.Rent == false).ToList();
            if (shops.Count !=0)
            {
                countshops = shops.Count;
                countshopssold = (shopsSold.Count * 100) / countshops;
                countshopssolds = countshopssold.ToString() + "%";
                countshopsfull = (shopsFull.Count * 100) / countshops;
                countshopsfulls = countshopsfull.ToString() + "%";
                countshopsempty = (shopsEmpty.Count * 100) / countshops;
                countshopsemptys = countshopsempty.ToString() + "%";
            }

            AccountRests = _shop_For_RentApplication.GetViewModel().Where(x => x.Status == true && x.Rest != 0).ToList();
            payboxs = _payBoxApplication.GetPayBox().Where(x => x.Status == true).ToList();
            employees = _employeeApplication.GetEmployee().Where(x => x.Status == true && x.Access == true && x.Rest != 0).ToList();
            persons = _personApplication.GetPerson().Where(x => x.Status == true && x.Rest != 0).ToList();
            meters = _meterApplication.GetViewModel().Where(x => x.Status == true && x.Rest != 0).ToList();
            forrents = _shop_For_RentApplication.GetViewModel();
            solds = _soldApplication.GetViewModel();

            payboxsRest = payboxs.Sum(x => x.Rest);
            AccountRest = AccountRests.Sum(x => x.Rest);
            metersRest = meters.Sum(x => x.Rest);
            personsRest= persons.Sum(x => x.Rest);
            employeesRest= employees.Sum(x => x.Rest);
        }
    }
}