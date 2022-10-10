using _0_Framework.Application;
using _01_Fazli_MarketQuery.Contracts.Rent;
using AccountManagement.Application.Contracts.Locations;
using AccountManagement.Application.Contracts.Money;
using AccountManagement.Application.Contracts.PayBox;
using AccountManagement.Application.Contracts.ReceiptRent;
using AccountManagement.Application.Contracts.Shop;
using AccountManagement.Application.Contracts.Shop_For_Rent;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Areas.Administration.Pages.Accounts.ShopAccounts.ReceiptRent
{
    public class PrintModel : PageModel
    {
        public ReceiptRents receiptRent;
        private readonly ILocation_Application _location_Application;
        private readonly IShop_Application _shop_Application;
        private readonly IShop_For_RentApplication _shop_For_RentApplication;
        private readonly IPayBoxApplication _payBoxApplication;
        private readonly IMoneyApplication _moneyApplication;
        private readonly IReceiptRentApplication _receiptRentApplication;
        public PrintModel(IShop_For_RentApplication shop_For_RentApplication, IShop_Application shop_Application,
            ILocation_Application location_Application, IPayBoxApplication payBoxApplication,
            IMoneyApplication moneyApplication, IReceiptRentApplication receiptRentApplication)
        {
            _shop_For_RentApplication = shop_For_RentApplication;
            _shop_Application = shop_Application;
            _location_Application = location_Application;
            _payBoxApplication = payBoxApplication;
            _moneyApplication = moneyApplication;
            _receiptRentApplication = receiptRentApplication;
        }

        public void OnGet(int id, ReceiptRentCreate command)
        {
            _shop_For_RentApplication.Total_Rest();
            PNumberTString dd = new PNumberTString();
            if (id != 0)
            {
                var receiptrent = _receiptRentApplication.GetDetails(id);
                var shop = _shop_Application.GetDetails(receiptrent.Shop_Id);
                var loca = _location_Application.GetDetails(shop.Location_Id);
                var forren = _shop_For_RentApplication.GetDetails(receiptrent.ForRent_Id);
                var paybox = _payBoxApplication.GetDetails(receiptrent.PayBox_Id);
                var money = _moneyApplication.GetDetails(forren.Money_Id);
                receiptRent = new ReceiptRents()
                {
                    Date = receiptrent.Date,
                    ReceiptNumber = "1",
                    ForRentName = forren.Name,
                    Location = loca.Name,
                    Shop = shop.Name,
                    ForRentRest = (int)forren.Rent,
                    By = paybox.Name,
                    Months = receiptrent.Months.ToMonth(),
                    Years = receiptrent.Years,
                    Rest = (int)forren.Rest,
                    RentRest = receiptrent.Shop_Amount,
                    Total_Persian = dd.num2str(receiptrent.Shop_Amount.ToString()),
                    Money = money.Name,
                    Shop_Id = receiptrent.Shop_Id
                };
            }
            else
            {
                var shop = _shop_Application.GetDetails(command.Shop_Id);
                var loca = _location_Application.GetDetails(shop.Location_Id);
                var forren = _shop_For_RentApplication.GetDetails(command.ForRent_Id);
                var paybox = _payBoxApplication.GetDetails(command.PayBox_Id);
                var money = _moneyApplication.GetDetails(forren.Money_Id);
                receiptRent = new ReceiptRents()
                {
                    Date = command.Date,
                    ReceiptNumber = "1",
                    ForRentName = forren.Name,
                    Location = loca.Name,
                    Shop = shop.Name,
                    ForRentRest = (int)forren.Rent,
                    By = paybox.Name,
                    Months = command.Months.ToMonth(),
                    Years = command.Years,
                    Rest = (int)forren.Rest,
                    RentRest = command.Shop_Amount,
                    Total_Persian = dd.num2str(command.Shop_Amount.ToString()),
                    Money = money.Name,
                    Shop_Id = command.Shop_Id
                };
            }
        }
    }
}