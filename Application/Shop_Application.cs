using _0_Framework.Application;
using AccountManagement.Application.Contracts.Shop;
using Domin.ReceiptRentAgg;
using Domin.RentAgg;
using Domin.Shop_For_RentAgg;
using Domin.ShopAgg;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Application
{
    public class Shop_Application : IShop_Application
    {
        private readonly IShop_Repository _shopRepository;
        private readonly IAuthHelper ـauthHelper;
        private readonly IShopForRentRepository _shop_For_RentRepository;
        private readonly IRentRepository _rentRepository;
        private readonly IReceiptRentRepository _receiptRentRepository;
        public Shop_Application(IShop_Repository shopRepository, IAuthHelper ـauthHelper,
            IShopForRentRepository shop_For_RentRepository, IRentRepository rentRepository, IReceiptRentRepository receiptRentRepository)
        {
            _shopRepository = shopRepository;
            this.ـauthHelper = ـauthHelper;
            _shop_For_RentRepository = shop_For_RentRepository;
            _rentRepository = rentRepository;
            _receiptRentRepository = receiptRentRepository;
        }
        public OperationResult Create(Create_Shop command)
        {
            var operation = new OperationResult();
            if (_shopRepository.Exists(x => x.Location_Id == command.Location_Id && x.Name == command.Name))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);

            int userid = ـauthHelper.CurrentAccountId();
            var result = new Shop(command.Location_Id, command.Name, userid);
            _shopRepository.Create(result);
            _shopRepository.SaveChanges();
            return operation.Succedded();
        }
        public OperationResult Edit(Edit_Shop command)
        {
            var operation = new OperationResult();
            var result = _shopRepository.Get(command.Id);
            if (result == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);

            if (_shopRepository.Exists(x => x.Location_Id == command.Location_Id && x.Name == command.Name && x.Id != command.Id))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);

            int userid = ـauthHelper.CurrentAccountId();
            result.Edit(command.Location_Id, command.Name, userid);
            _shopRepository.SaveChanges();
            return operation.Succedded();
        }
        public Edit_Shop GetDetails(int id)
        {
            return _shopRepository.GetDetails(id);
        }
        public List<ViewModel_Shop> GetShop()
        {
            return _shopRepository.GetShop();
        }
        public List<ViewModel_Locations> GetLocations(int Location_Id)
        {
            return _shopRepository.GetLocations(Location_Id);
        }
        public void Remove(int id)
        {
            var money = _shopRepository.Get(id);
            money.Remove();
            _shopRepository.SaveChanges();
        }
        public void Activate(int id)
        {
            var money = _shopRepository.Get(id);
            money.Activate();
            _shopRepository.SaveChanges();
        }
        public OperationResult Full(Date_Shop command)
        {
            var operation = new OperationResult();
            var result = _shopRepository.Get(command.Id);
            if (result == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);

            result.Full(command.Start_Date);
            _shopRepository.SaveChanges();
            return operation.Succedded();
        }
        public OperationResult Empty(Date_Shop command)
        {
            var operation = new OperationResult();
            var result = _shopRepository.Get(command.Id);
            if (result == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);

            result.Empty(command.End_Date);
            _shopRepository.SaveChanges();
            return operation.Succedded();
        }
        public void Rest(int id, string date)
        {
            var result = _shopRepository.Get(id);
            result.Edit(date);
            _shopRepository.SaveChanges();
        }
        public void ShopSold(int id)
        {
            var result = _shopRepository.Get(id);
            result.ShopSold();
            _shopRepository.SaveChanges();
        }
        public void ShopRent(int id)
        {
            var result = _shopRepository.Get(id);
            result.ShopRent();
            _shopRepository.SaveChanges();
        }
        public void Rest()
        {
            string date = DateTime.Now.ToFarsi();
            var year = Convert.ToInt32(date.Substring(0, 4));
            var month = Convert.ToInt32(date.Substring(5, 2));

            var shopsFull = _shopRepository.GetShop().Where(x => x.Status == true && x.Sold == false && x.Rent == true).ToList();
            foreach (var Full in shopsFull)
            {
                string shopdate = Full.Date;
                if (shopdate != null)
                {
                    var years = Convert.ToInt32(shopdate.Substring(0, 4));
                    var months = Convert.ToInt32(shopdate.Substring(5, 2));
                    if (year != years)
                    {
                        for (int y = years; y < year; y++)
                        {
                            for (int i = months; i < 13; i++)
                            {
                                var forrent = _shop_For_RentRepository.GetDetails(Full.Id_Shopkeeper);
                                var rents = _rentRepository.Get_Id(Full.Id, forrent.Money_Id, forrent.Id);
                                if (rents != null)
                                {
                                    if (rents.Shop_Id == Full.Id && rents.Money_Id == forrent.Money_Id && rents.Year == y && rents.ForRent_Id == forrent.Id)
                                    {
                                        var rent = _rentRepository.Get(rents.Id);
                                        switch (i)
                                        {
                                            case 1:
                                                rent.Month1(forrent.Rent);
                                                _rentRepository.SaveChanges();
                                                break;
                                            case 2:
                                                rent.Month2(forrent.Rent);
                                                _rentRepository.SaveChanges();
                                                break;
                                            case 3:
                                                rent.Month3(forrent.Rent);
                                                _rentRepository.SaveChanges();
                                                break;
                                            case 4:
                                                rent.Month4(forrent.Rent);
                                                _rentRepository.SaveChanges();
                                                break;
                                            case 5:
                                                rent.Month5(forrent.Rent);
                                                _rentRepository.SaveChanges();
                                                break;
                                            case 6:
                                                rent.Month6(forrent.Rent);
                                                _rentRepository.SaveChanges();
                                                break;
                                            case 7:
                                                rent.Month7(forrent.Rent);
                                                _rentRepository.SaveChanges();
                                                break;
                                            case 8:
                                                rent.Month8(forrent.Rent);
                                                _rentRepository.SaveChanges();
                                                break;
                                            case 9:
                                                rent.Month9(forrent.Rent);
                                                _rentRepository.SaveChanges();
                                                break;
                                            case 10:
                                                rent.Month10(forrent.Rent);
                                                _rentRepository.SaveChanges();
                                                break;
                                            case 11:
                                                rent.Month11(forrent.Rent);
                                                _rentRepository.SaveChanges();
                                                break;
                                            case 12:
                                                rent.Month12(forrent.Rent);
                                                _rentRepository.SaveChanges();
                                                break;
                                        }
                                    }
                                    else
                                    {
                                        switch (i)
                                        {
                                            case 1:
                                                var result = new Rent(y, forrent.Rent, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, Full.Id, forrent.Money_Id, forrent.Id);
                                                _rentRepository.Create(result);
                                                _rentRepository.SaveChanges();
                                                break;
                                            case 2:
                                                var result1 = new Rent(y, 0, forrent.Rent, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, Full.Id, forrent.Money_Id, forrent.Id);
                                                _rentRepository.Create(result1);
                                                _rentRepository.SaveChanges();
                                                break;
                                            case 3:
                                                var result2 = new Rent(y, 0, 0, forrent.Rent, 0, 0, 0, 0, 0, 0, 0, 0, 0, Full.Id, forrent.Money_Id, forrent.Id);
                                                _rentRepository.Create(result2);
                                                _rentRepository.SaveChanges();
                                                break;
                                            case 4:
                                                var result3 = new Rent(y, 0, 0, 0, forrent.Rent, 0, 0, 0, 0, 0, 0, 0, 0, Full.Id, forrent.Money_Id, forrent.Id);
                                                _rentRepository.Create(result3);
                                                _rentRepository.SaveChanges();
                                                break;
                                            case 5:
                                                var result4 = new Rent(y, 0, 0, 0, 0, forrent.Rent, 0, 0, 0, 0, 0, 0, 0, Full.Id, forrent.Money_Id, forrent.Id);
                                                _rentRepository.Create(result4);
                                                _rentRepository.SaveChanges();
                                                break;
                                            case 6:
                                                var result5 = new Rent(y, 0, 0, 0, 0, 0, forrent.Rent, 0, 0, 0, 0, 0, 0, Full.Id, forrent.Money_Id, forrent.Id);
                                                _rentRepository.Create(result5);
                                                _rentRepository.SaveChanges();
                                                break;
                                            case 7:
                                                var result6 = new Rent(y, 0, 0, 0, 0, 0, 0, forrent.Rent, 0, 0, 0, 0, 0, Full.Id, forrent.Money_Id, forrent.Id);
                                                _rentRepository.Create(result6);
                                                _rentRepository.SaveChanges();
                                                break;
                                            case 8:
                                                var result7 = new Rent(y, 0, 0, 0, 0, 0, 0, 0, forrent.Rent, 0, 0, 0, 0, Full.Id, forrent.Money_Id, forrent.Id);
                                                _rentRepository.Create(result7);
                                                _rentRepository.SaveChanges();
                                                break;
                                            case 9:
                                                var result8 = new Rent(y, 0, 0, 0, 0, 0, 0, 0, 0, forrent.Rent, 0, 0, 0, Full.Id, forrent.Money_Id, forrent.Id);
                                                _rentRepository.Create(result8);
                                                _rentRepository.SaveChanges();
                                                break;
                                            case 10:
                                                var result9 = new Rent(y, 0, 0, 0, 0, 0, 0, 0, 0, 0, forrent.Rent, 0, 0, Full.Id, forrent.Money_Id, forrent.Id);
                                                _rentRepository.Create(result9);
                                                _rentRepository.SaveChanges();
                                                break;
                                            case 11:
                                                var result10 = new Rent(y, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, forrent.Rent, 0, Full.Id, forrent.Money_Id, forrent.Id);
                                                _rentRepository.Create(result10);
                                                _rentRepository.SaveChanges();
                                                break;
                                            case 12:
                                                var result11 = new Rent(y, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, forrent.Rent, Full.Id, forrent.Money_Id, forrent.Id);
                                                _rentRepository.Create(result11);
                                                _rentRepository.SaveChanges();
                                                break;
                                        }
                                    }
                                }
                                else
                                {
                                    switch (i)
                                    {
                                        case 1:
                                            var result = new Rent(y, forrent.Rent, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, Full.Id, forrent.Money_Id, forrent.Id);
                                            _rentRepository.Create(result);
                                            _rentRepository.SaveChanges();
                                            break;
                                        case 2:
                                            var result1 = new Rent(y, 0, forrent.Rent, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, Full.Id, forrent.Money_Id, forrent.Id);
                                            _rentRepository.Create(result1);
                                            _rentRepository.SaveChanges();
                                            break;
                                        case 3:
                                            var result2 = new Rent(y, 0, 0, forrent.Rent, 0, 0, 0, 0, 0, 0, 0, 0, 0, Full.Id, forrent.Money_Id, forrent.Id);
                                            _rentRepository.Create(result2);
                                            _rentRepository.SaveChanges();
                                            break;
                                        case 4:
                                            var result3 = new Rent(y, 0, 0, 0, forrent.Rent, 0, 0, 0, 0, 0, 0, 0, 0, Full.Id, forrent.Money_Id, forrent.Id);
                                            _rentRepository.Create(result3);
                                            _rentRepository.SaveChanges();
                                            break;
                                        case 5:
                                            var result4 = new Rent(y, 0, 0, 0, 0, forrent.Rent, 0, 0, 0, 0, 0, 0, 0, Full.Id, forrent.Money_Id, forrent.Id);
                                            _rentRepository.Create(result4);
                                            _rentRepository.SaveChanges();
                                            break;
                                        case 6:
                                            var result5 = new Rent(y, 0, 0, 0, 0, 0, forrent.Rent, 0, 0, 0, 0, 0, 0, Full.Id, forrent.Money_Id, forrent.Id);
                                            _rentRepository.Create(result5);
                                            _rentRepository.SaveChanges();
                                            break;
                                        case 7:
                                            var result6 = new Rent(y, 0, 0, 0, 0, 0, 0, forrent.Rent, 0, 0, 0, 0, 0, Full.Id, forrent.Money_Id, forrent.Id);
                                            _rentRepository.Create(result6);
                                            _rentRepository.SaveChanges();
                                            break;
                                        case 8:
                                            var result7 = new Rent(y, 0, 0, 0, 0, 0, 0, 0, forrent.Rent, 0, 0, 0, 0, Full.Id, forrent.Money_Id, forrent.Id);
                                            _rentRepository.Create(result7);
                                            _rentRepository.SaveChanges();
                                            break;
                                        case 9:
                                            var result8 = new Rent(y, 0, 0, 0, 0, 0, 0, 0, 0, forrent.Rent, 0, 0, 0, Full.Id, forrent.Money_Id, forrent.Id);
                                            _rentRepository.Create(result8);
                                            _rentRepository.SaveChanges();
                                            break;
                                        case 10:
                                            var result9 = new Rent(y, 0, 0, 0, 0, 0, 0, 0, 0, 0, forrent.Rent, 0, 0, Full.Id, forrent.Money_Id, forrent.Id);
                                            _rentRepository.Create(result9);
                                            _rentRepository.SaveChanges();
                                            break;
                                        case 11:
                                            var result10 = new Rent(y, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, forrent.Rent, 0, Full.Id, forrent.Money_Id, forrent.Id);
                                            _rentRepository.Create(result10);
                                            _rentRepository.SaveChanges();
                                            break;
                                        case 12:
                                            var result11 = new Rent(y, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, forrent.Rent, Full.Id, forrent.Money_Id, forrent.Id);
                                            _rentRepository.Create(result11);
                                            _rentRepository.SaveChanges();
                                            break;
                                    }
                                }
                            }
                        }
                        years = year;
                        months = 1;
                    }
                    if (year == years)
                    {
                        for (int i = months; i < month; i++)
                        {
                            var forrent = _shop_For_RentRepository.GetDetails(Full.Id_Shopkeeper);
                            var rents = _rentRepository.GetViewModel().FirstOrDefault(x => x.Shop_Id == Full.Id && x.Money_Id == forrent.Money_Id && x.Year == year && x.ForRent_Id == forrent.Id);
                            if (rents != null)
                            {
                                if (rents.Shop_Id == Full.Id && rents.Money_Id == forrent.Money_Id && rents.Year == year && rents.ForRent_Id == forrent.Id)
                                {
                                    var rent = _rentRepository.Get(rents.Id);
                                    switch (i)
                                    {
                                        case 1:
                                            rent.Month1(forrent.Rent);
                                            _rentRepository.SaveChanges();
                                            break;
                                        case 2:
                                            rent.Month2(forrent.Rent);
                                            _rentRepository.SaveChanges();
                                            break;
                                        case 3:
                                            rent.Month3(forrent.Rent);
                                            _rentRepository.SaveChanges();
                                            break;
                                        case 4:
                                            rent.Month4(forrent.Rent);
                                            _rentRepository.SaveChanges();
                                            break;
                                        case 5:
                                            rent.Month5(forrent.Rent);
                                            _rentRepository.SaveChanges();
                                            break;
                                        case 6:
                                            rent.Month6(forrent.Rent);
                                            _rentRepository.SaveChanges();
                                            break;
                                        case 7:
                                            rent.Month7(forrent.Rent);
                                            _rentRepository.SaveChanges();
                                            break;
                                        case 8:
                                            rent.Month8(forrent.Rent);
                                            _rentRepository.SaveChanges();
                                            break;
                                        case 9:
                                            rent.Month9(forrent.Rent);
                                            _rentRepository.SaveChanges();
                                            break;
                                        case 10:
                                            rent.Month10(forrent.Rent);
                                            _rentRepository.SaveChanges();
                                            break;
                                        case 11:
                                            rent.Month11(forrent.Rent);
                                            _rentRepository.SaveChanges();
                                            break;
                                        case 12:
                                            rent.Month12(forrent.Rent);
                                            _rentRepository.SaveChanges();
                                            break;
                                    }
                                }
                                else
                                {
                                    switch (i)
                                    {
                                        case 1:
                                            var result = new Rent(year, forrent.Rent, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, Full.Id, forrent.Money_Id, forrent.Id);
                                            _rentRepository.Create(result);
                                            _rentRepository.SaveChanges();
                                            break;
                                        case 2:
                                            var result1 = new Rent(year, 0, forrent.Rent, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, Full.Id, forrent.Money_Id, forrent.Id);
                                            _rentRepository.Create(result1);
                                            _rentRepository.SaveChanges();
                                            break;
                                        case 3:
                                            var result2 = new Rent(year, 0, 0, forrent.Rent, 0, 0, 0, 0, 0, 0, 0, 0, 0, Full.Id, forrent.Money_Id, forrent.Id);
                                            _rentRepository.Create(result2);
                                            _rentRepository.SaveChanges();
                                            break;
                                        case 4:
                                            var result3 = new Rent(year, 0, 0, 0, forrent.Rent, 0, 0, 0, 0, 0, 0, 0, 0, Full.Id, forrent.Money_Id, forrent.Id);
                                            _rentRepository.Create(result3);
                                            _rentRepository.SaveChanges();
                                            break;
                                        case 5:
                                            var result4 = new Rent(year, 0, 0, 0, 0, forrent.Rent, 0, 0, 0, 0, 0, 0, 0, Full.Id, forrent.Money_Id, forrent.Id);
                                            _rentRepository.Create(result4);
                                            _rentRepository.SaveChanges();
                                            break;
                                        case 6:
                                            var result5 = new Rent(year, 0, 0, 0, 0, 0, forrent.Rent, 0, 0, 0, 0, 0, 0, Full.Id, forrent.Money_Id, forrent.Id);
                                            _rentRepository.Create(result5);
                                            _rentRepository.SaveChanges();
                                            break;
                                        case 7:
                                            var result6 = new Rent(year, 0, 0, 0, 0, 0, 0, forrent.Rent, 0, 0, 0, 0, 0, Full.Id, forrent.Money_Id, forrent.Id);
                                            _rentRepository.Create(result6);
                                            _rentRepository.SaveChanges();
                                            break;
                                        case 8:
                                            var result7 = new Rent(year, 0, 0, 0, 0, 0, 0, 0, forrent.Rent, 0, 0, 0, 0, Full.Id, forrent.Money_Id, forrent.Id);
                                            _rentRepository.Create(result7);
                                            _rentRepository.SaveChanges();
                                            break;
                                        case 9:
                                            var result8 = new Rent(year, 0, 0, 0, 0, 0, 0, 0, 0, forrent.Rent, 0, 0, 0, Full.Id, forrent.Money_Id, forrent.Id);
                                            _rentRepository.Create(result8);
                                            _rentRepository.SaveChanges();
                                            break;
                                        case 10:
                                            var result9 = new Rent(year, 0, 0, 0, 0, 0, 0, 0, 0, 0, forrent.Rent, 0, 0, Full.Id, forrent.Money_Id, forrent.Id);
                                            _rentRepository.Create(result9);
                                            _rentRepository.SaveChanges();
                                            break;
                                        case 11:
                                            var result10 = new Rent(year, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, forrent.Rent, 0, Full.Id, forrent.Money_Id, forrent.Id);
                                            _rentRepository.Create(result10);
                                            _rentRepository.SaveChanges();
                                            break;
                                        case 12:
                                            var result11 = new Rent(year, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, forrent.Rent, Full.Id, forrent.Money_Id, forrent.Id);
                                            _rentRepository.Create(result11);
                                            _rentRepository.SaveChanges();
                                            break;
                                    }
                                }
                            }
                            else
                            {
                                switch (i)
                                {
                                    case 1:
                                        var result = new Rent(year, forrent.Rent, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, Full.Id, forrent.Money_Id, forrent.Id);
                                        _rentRepository.Create(result);
                                        _rentRepository.SaveChanges();
                                        break;
                                    case 2:
                                        var result1 = new Rent(year, 0, forrent.Rent, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, Full.Id, forrent.Money_Id, forrent.Id);
                                        _rentRepository.Create(result1);
                                        _rentRepository.SaveChanges();
                                        break;
                                    case 3:
                                        var result2 = new Rent(year, 0, 0, forrent.Rent, 0, 0, 0, 0, 0, 0, 0, 0, 0, Full.Id, forrent.Money_Id, forrent.Id);
                                        _rentRepository.Create(result2);
                                        _rentRepository.SaveChanges();
                                        break;
                                    case 4:
                                        var result3 = new Rent(year, 0, 0, 0, forrent.Rent, 0, 0, 0, 0, 0, 0, 0, 0, Full.Id, forrent.Money_Id, forrent.Id);
                                        _rentRepository.Create(result3);
                                        _rentRepository.SaveChanges();
                                        break;
                                    case 5:
                                        var result4 = new Rent(year, 0, 0, 0, 0, forrent.Rent, 0, 0, 0, 0, 0, 0, 0, Full.Id, forrent.Money_Id, forrent.Id);
                                        _rentRepository.Create(result4);
                                        _rentRepository.SaveChanges();
                                        break;
                                    case 6:
                                        var result5 = new Rent(year, 0, 0, 0, 0, 0, forrent.Rent, 0, 0, 0, 0, 0, 0, Full.Id, forrent.Money_Id, forrent.Id);
                                        _rentRepository.Create(result5);
                                        _rentRepository.SaveChanges();
                                        break;
                                    case 7:
                                        var result6 = new Rent(year, 0, 0, 0, 0, 0, 0, forrent.Rent, 0, 0, 0, 0, 0, Full.Id, forrent.Money_Id, forrent.Id);
                                        _rentRepository.Create(result6);
                                        _rentRepository.SaveChanges();
                                        break;
                                    case 8:
                                        var result7 = new Rent(year, 0, 0, 0, 0, 0, 0, 0, forrent.Rent, 0, 0, 0, 0, Full.Id, forrent.Money_Id, forrent.Id);
                                        _rentRepository.Create(result7);
                                        _rentRepository.SaveChanges();
                                        break;
                                    case 9:
                                        var result8 = new Rent(year, 0, 0, 0, 0, 0, 0, 0, 0, forrent.Rent, 0, 0, 0, Full.Id, forrent.Money_Id, forrent.Id);
                                        _rentRepository.Create(result8);
                                        _rentRepository.SaveChanges();
                                        break;
                                    case 10:
                                        var result9 = new Rent(year, 0, 0, 0, 0, 0, 0, 0, 0, 0, forrent.Rent, 0, 0, Full.Id, forrent.Money_Id, forrent.Id);
                                        _rentRepository.Create(result9);
                                        _rentRepository.SaveChanges();
                                        break;
                                    case 11:
                                        var result10 = new Rent(year, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, forrent.Rent, 0, Full.Id, forrent.Money_Id, forrent.Id);
                                        _rentRepository.Create(result10);
                                        _rentRepository.SaveChanges();
                                        break;
                                    case 12:
                                        var result11 = new Rent(year, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, forrent.Rent, Full.Id, forrent.Money_Id, forrent.Id);
                                        _rentRepository.Create(result11);
                                        _rentRepository.SaveChanges();
                                        break;
                                }
                            }
                        }
                    }
                    var resultshop = _shopRepository.Get(Full.Id);
                    resultshop.Edit(date);
                    _shopRepository.SaveChanges();
                }
            }

            var resalt = _shop_For_RentRepository.GetViewModel();
            if (resalt != null)
            {
                foreach (var item in resalt)
                {
                    decimal receipt = _receiptRentRepository.GetReceiptRent()
                        .Where(x => x.Status == true && x.ForRent_Id == item.Id).Sum(x => x.Shop_Amount);

                    decimal Month1 = _rentRepository.GetViewModel()
                        .Where(x => x.Status == true && x.Shop_Id == item.Id_Shop && x.Money_Id == item.Id_Money && x.ForRent_Id == item.Id).Sum(x => x.Month_1);
                    decimal Month2 = _rentRepository.GetViewModel()
                        .Where(x => x.Status == true && x.Shop_Id == item.Id_Shop && x.Money_Id == item.Id_Money && x.ForRent_Id == item.Id).Sum(x => x.Month_2);
                    decimal Month3 = _rentRepository.GetViewModel()
                        .Where(x => x.Status == true && x.Shop_Id == item.Id_Shop && x.Money_Id == item.Id_Money && x.ForRent_Id == item.Id).Sum(x => x.Month_3);
                    decimal Month4 = _rentRepository.GetViewModel()
                        .Where(x => x.Status == true && x.Shop_Id == item.Id_Shop && x.Money_Id == item.Id_Money && x.ForRent_Id == item.Id).Sum(x => x.Month_4);
                    decimal Month5 = _rentRepository.GetViewModel()
                        .Where(x => x.Status == true && x.Shop_Id == item.Id_Shop && x.Money_Id == item.Id_Money && x.ForRent_Id == item.Id).Sum(x => x.Month_5);
                    decimal Month6 = _rentRepository.GetViewModel()
                        .Where(x => x.Status == true && x.Shop_Id == item.Id_Shop && x.Money_Id == item.Id_Money && x.ForRent_Id == item.Id).Sum(x => x.Month_6);
                    decimal Month7 = _rentRepository.GetViewModel()
                        .Where(x => x.Status == true && x.Shop_Id == item.Id_Shop && x.Money_Id == item.Id_Money && x.ForRent_Id == item.Id).Sum(x => x.Month_7);
                    decimal Month8 = _rentRepository.GetViewModel()
                        .Where(x => x.Status == true && x.Shop_Id == item.Id_Shop && x.Money_Id == item.Id_Money && x.ForRent_Id == item.Id).Sum(x => x.Month_8);
                    decimal Month9 = _rentRepository.GetViewModel()
                        .Where(x => x.Status == true && x.Shop_Id == item.Id_Shop && x.Money_Id == item.Id_Money && x.ForRent_Id == item.Id).Sum(x => x.Month_9);
                    decimal Month10 = _rentRepository.GetViewModel()
                        .Where(x => x.Status == true && x.Shop_Id == item.Id_Shop && x.Money_Id == item.Id_Money && x.ForRent_Id == item.Id).Sum(x => x.Month_10);
                    decimal Month11 = _rentRepository.GetViewModel()
                        .Where(x => x.Status == true && x.Shop_Id == item.Id_Shop && x.Money_Id == item.Id_Money && x.ForRent_Id == item.Id).Sum(x => x.Month_11);
                    decimal Month12 = _rentRepository.GetViewModel()
                        .Where(x => x.Status == true && x.Shop_Id == item.Id_Shop && x.Money_Id == item.Id_Money && x.ForRent_Id == item.Id).Sum(x => x.Month_12);

                    decimal Months = Month1 + Month2 + Month3 + Month4 + Month5 + Month6 + Month7 + Month8 + Month9 + Month10 + Month11 + Month12;

                    decimal rent = Months - receipt;
                    var shopForRent = _shop_For_RentRepository.Get(item.Id);
                    shopForRent.Edit(rent);
                    _shop_For_RentRepository.SaveChanges();

                }
            }

            var Shops = _shopRepository.GetShop();
            if (Shops != null)
            {
                foreach (var item_Shop in Shops)
                {
                    decimal receipt = _receiptRentRepository.GetReceiptRent().Where(x => x.Status == true && x.Shop_Id == item_Shop.Id).Sum(x => x.Shop_Amount);

                    decimal Month1 = _rentRepository.GetViewModel().Where(x => x.Status == true && x.Shop_Id == item_Shop.Id).Sum(x => x.Month_1);
                    decimal Month2 = _rentRepository.GetViewModel().Where(x => x.Status == true && x.Shop_Id == item_Shop.Id).Sum(x => x.Month_2);
                    decimal Month3 = _rentRepository.GetViewModel().Where(x => x.Status == true && x.Shop_Id == item_Shop.Id).Sum(x => x.Month_3);
                    decimal Month4 = _rentRepository.GetViewModel().Where(x => x.Status == true && x.Shop_Id == item_Shop.Id).Sum(x => x.Month_4);
                    decimal Month5 = _rentRepository.GetViewModel().Where(x => x.Status == true && x.Shop_Id == item_Shop.Id).Sum(x => x.Month_5);
                    decimal Month6 = _rentRepository.GetViewModel().Where(x => x.Status == true && x.Shop_Id == item_Shop.Id).Sum(x => x.Month_6);
                    decimal Month7 = _rentRepository.GetViewModel().Where(x => x.Status == true && x.Shop_Id == item_Shop.Id).Sum(x => x.Month_7);
                    decimal Month8 = _rentRepository.GetViewModel().Where(x => x.Status == true && x.Shop_Id == item_Shop.Id).Sum(x => x.Month_8);
                    decimal Month9 = _rentRepository.GetViewModel().Where(x => x.Status == true && x.Shop_Id == item_Shop.Id).Sum(x => x.Month_9);
                    decimal Month10 = _rentRepository.GetViewModel().Where(x => x.Status == true && x.Shop_Id == item_Shop.Id).Sum(x => x.Month_10);
                    decimal Month11 = _rentRepository.GetViewModel().Where(x => x.Status == true && x.Shop_Id == item_Shop.Id).Sum(x => x.Month_11);
                    decimal Month12 = _rentRepository.GetViewModel().Where(x => x.Status == true && x.Shop_Id == item_Shop.Id).Sum(x => x.Month_12);

                    decimal Months = Month1 + Month2 + Month3 + Month4 + Month5 + Month6 + Month7 + Month8 + Month9 + Month10 + Month11 + Month12;

                    decimal rent = Months - receipt;
                    var shop = _shopRepository.Get(item_Shop.Id);
                    shop.Edit(rent);
                    _shopRepository.SaveChanges();

                }
            }
        }
    }
}