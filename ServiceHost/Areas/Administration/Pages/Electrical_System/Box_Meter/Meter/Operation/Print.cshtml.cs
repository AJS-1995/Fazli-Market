using _01_Fazli_MarketQuery.Contracts.Electrical_System.Box_Meter;
using AccountManagement.Application.Contracts.Electrical_System.Box_Meter;
using AccountManagement.Application.Contracts.Electrical_System.Box_Meter.Meter;
using AccountManagement.Application.Contracts.Locations;
using AccountManagement.Application.Contracts.Shop;
using Microsoft.AspNetCore.Mvc.RazorPages;
using _0_Framework.Application;
using AccountManagement.Application.Contracts.Shop_For_Rent;
using AccountManagement.Application.Contracts.Sold;

namespace ServiceHost.Areas.Administration.Pages.Electrical_System.Box_Meter.Meter.Operation
{
    public class PrintModel : PageModel
    {
        public Meter_Op meter_Op;
        private readonly IMeterApplication _meterApplication;
        private readonly IMOperationApplication _mOperationApplication;
        private readonly ILocation_Application _location_Application;
        private readonly IShop_Application _shop_Application;
        private readonly IShop_For_RentApplication _shop_For_RentApplication;
        private readonly ISoldApplication _soldApplication;
        private readonly IBoxMeterApplication _boxmeterApplication;
        public PrintModel(IMeterApplication meterApplication, ILocation_Application location_Application,
            IShop_Application shop_Application, IBoxMeterApplication boxmeterApplication,
            IShop_For_RentApplication shop_For_RentApplication, ISoldApplication soldApplication, IMOperationApplication mOperationApplication)
        {
            _meterApplication = meterApplication;
            _location_Application = location_Application;
            _shop_Application = shop_Application;
            _boxmeterApplication = boxmeterApplication;
            _shop_For_RentApplication = shop_For_RentApplication;
            _soldApplication = soldApplication;
            _mOperationApplication = mOperationApplication;
        }

        public void OnGet(int id, MOperationCreate command)
        {
            if (id != 0)
            {
                var mOperation = _mOperationApplication.GetDetails(id);
                var meter = _meterApplication.GetDetails(mOperation.Meter_Id);
                var boxmeter = _boxmeterApplication.GetDetails(meter.BoxMeter_Id);
                var shop = _shop_Application.GetDetails(meter.Shop_Id);
                var location = _location_Application.GetDetails(shop.Location_Id);
                PNumberTString dd = new PNumberTString();
                if (shop.Sold == false)
                {
                    var shopforrent = _shop_For_RentApplication.GetDetails(shop.Id_Shopkeeper);
                    meter_Op = new Meter_Op()
                    {
                        Meter_Id = mOperation.Meter_Id,
                        Date_Rrad = mOperation.Date_Rrad,
                        Date_Pay = mOperation.Date_Pay,
                        Meter_Cod = meter.Cod,
                        Location_M = boxmeter.Name,
                        Location_S = location.Name + " _ " + shop.Name,
                        ShopKeeper = shopforrent.Name,
                        Grade_Past = mOperation.Grade_Past,
                        Grade_Now = mOperation.Grade_Now,
                        Grade = mOperation.Grade,
                        Price = mOperation.Price,
                        Complete = mOperation.Complete,
                        Other = mOperation.Other,
                        Total = mOperation.Total,
                        Total_Persian = dd.num2str(mOperation.Total.ToString()),
                    };
                }
                else if (shop.Sold == true)
                {
                    var shopforrent = _soldApplication.GetDetails(shop.Id_Shopkeeper);
                    meter_Op = new Meter_Op()
                    {
                        Meter_Id = mOperation.Meter_Id,
                        Date_Rrad = mOperation.Date_Rrad,
                        Date_Pay = mOperation.Date_Pay,
                        Meter_Cod = meter.Cod,
                        Location_M = boxmeter.Name,
                        Location_S = location.Name + " _ " + shop.Name,
                        ShopKeeper = shopforrent.Name,
                        Grade_Past = mOperation.Grade_Past,
                        Grade_Now = mOperation.Grade_Now,
                        Grade = mOperation.Grade,
                        Price = mOperation.Price,
                        Complete = mOperation.Complete,
                        Other = mOperation.Other,
                        Total = mOperation.Total,
                        Total_Persian = dd.num2str(mOperation.Total.ToString()),
                    };
                }
            }
            else
            {
                var meter = _meterApplication.GetDetails(command.Meter_Id);
                var boxmeter = _boxmeterApplication.GetDetails(meter.BoxMeter_Id);
                var shop = _shop_Application.GetDetails(meter.Shop_Id);
                var location = _location_Application.GetDetails(shop.Location_Id);
                PNumberTString dd = new PNumberTString();
                if (shop.Sold == false)
                {
                    var shopforrent = _shop_For_RentApplication.GetDetails(shop.Id_Shopkeeper);
                    meter_Op = new Meter_Op()
                    {
                        Meter_Id = command.Meter_Id,
                        Date_Rrad = command.Date_Rrad,
                        Date_Pay = command.Date_Pay,
                        Meter_Cod = meter.Cod,
                        Location_M = boxmeter.Name,
                        Location_S = location.Name + " _ " + shop.Name,
                        ShopKeeper = shopforrent.Name,
                        Grade_Past = command.Grade_Past,
                        Grade_Now = command.Grade_Now,
                        Grade = command.Grade,
                        Price = command.Price,
                        Complete = command.Complete,
                        Other = command.Other,
                        Total = command.Total,
                        Total_Persian = dd.num2str(command.Total.ToString()),
                    };
                }
                else if (shop.Sold == true)
                {
                    var shopforrent = _soldApplication.GetDetails(shop.Id_Shopkeeper);
                    meter_Op = new Meter_Op()
                    {
                        Meter_Id = command.Meter_Id,
                        Date_Rrad = command.Date_Rrad,
                        Date_Pay = command.Date_Pay,
                        Meter_Cod = meter.Cod,
                        Location_M = boxmeter.Name,
                        Location_S = location.Name + " _ " + shop.Name,
                        ShopKeeper = shopforrent.Name,
                        Grade_Past = command.Grade_Past,
                        Grade_Now = command.Grade_Now,
                        Grade = command.Grade,
                        Price = command.Price,
                        Complete = command.Complete,
                        Other = command.Other,
                        Total = command.Total,
                        Total_Persian = dd.num2str(command.Total.ToString()),
                    };
                }
            }
        }
    }
}