using _0_Framework.Application;
using AccountManagement.Application.Contracts.Shop_For_Rent;
using Domin.ReceiptRentAgg;
using Domin.RentAgg;
using Domin.Shop_For_RentAgg;
using Domin.ShopAgg;
using System.Collections.Generic;
using System.Linq;

namespace Application
{
    public class Shop_For_RentApplication : IShop_For_RentApplication
    {
        private readonly IShopForRentRepository _shop_For_RentRepository;
        private readonly IShop_Repository _shopRepository;
        private readonly IAuthHelper ـauthHelper;
        private readonly IFileUploader _fileUploader;
        private readonly IReceiptRentRepository _receiptRentRepository;
        private readonly IRentRepository _rentRepository;
        public Shop_For_RentApplication(IShopForRentRepository shop_For_RentRepository, IAuthHelper ـauthHelper,
            IFileUploader fileUploader, IShop_Repository shopRepository, IReceiptRentRepository receiptRentRepository, IRentRepository rentRepository)
        {
            _shop_For_RentRepository = shop_For_RentRepository;
            this.ـauthHelper = ـauthHelper;
            _fileUploader = fileUploader;
            _shopRepository = shopRepository;
            _receiptRentRepository = receiptRentRepository;
            _rentRepository = rentRepository;
        }
        public void Activate(int id)
        {
            var resalt = _shop_For_RentRepository.Get(id);
            resalt.Activate();
            _shop_For_RentRepository.SaveChanges();
        }

        public OperationResult Create(Create_ShopForRent command)
        {
            var Operation = new OperationResult();
            if (_shop_For_RentRepository.Exists(x => x.Name == command.Name && x.Shop_Id == command.Shop_Id))
            {
                return Operation.Failed(ApplicationMessages.DuplicatedRecord);
            }
            else
            {
                decimal RentType = decimal.Parse(command.Rent.ToString());
                decimal Rent = decimal.Round(RentType, 2);

                var Id_Card_ScanPath = "Shop_For_Rent";
                var Id_Card_Scanname = command.Id_Card;
                var Id_Card_Scan = _fileUploader.Upload(command.Id_Card_Scan, Id_Card_ScanPath, Id_Card_Scanname);

                var Line_Contract_ScanPath = "Shop_For_Rent";
                var Line_Contract_Scanname = (command.Name + command.Shops).Slugify();
                var Line_Contract_ScanId_Card_Scan = _fileUploader.Upload(command.Line_Contract_Scan, Line_Contract_ScanPath, Line_Contract_Scanname);

                int userid = ـauthHelper.CurrentAccountId();
                var result = new ShopForRent(command.Name, command.Company, command.Phone, command.Address,
                    command.Id_Card, Id_Card_Scan, Line_Contract_ScanId_Card_Scan, command.Start_Date, command.End_Date,
                    Rent, command.Money_Id, command.Shop_Id, userid);
                _shop_For_RentRepository.Create(result);
                _shop_For_RentRepository.SaveChanges();

                var rent = _shopRepository.Get(command.Shop_Id);
                rent.Edit(true, result.Id);
                rent.Full(command.Start_Date);
                rent.Edit(command.Start_Date);
                _shopRepository.SaveChanges();

                return Operation.Succedded();
            }
        }

        public OperationResult Edit(Edit_ShopForRent command)
        {
            var operation = new OperationResult();
            var result = _shop_For_RentRepository.Get(command.Id);
            if (result == null)
            {
                return operation.Failed(ApplicationMessages.DuplicatedRecord);
            }
            else
            {
                if (_shop_For_RentRepository.Exists(x => x.Name == command.Name && x.Shop_Id == command.Shop_Id && x.Id != command.Id))
                {
                    return operation.Failed(ApplicationMessages.DuplicatedRecord);
                }
                else
                {
                    decimal RentType = decimal.Parse(command.Rent.ToString());
                    decimal Rent = decimal.Round(RentType, 2);

                    var Id_Card_ScanPath = "Shop_For_Rent";
                    var Id_Card_Scanname = command.Id_Card;
                    var Id_Card_Scan = _fileUploader.Upload(command.Id_Card_Scan, Id_Card_ScanPath, Id_Card_Scanname);

                    var Line_Contract_ScanPath = "Shop_For_Rent";
                    var Line_Contract_Scanname = (command.Name + command.Shops).Slugify();
                    var Line_Contract_ScanId_Card_Scan = _fileUploader.Upload(command.Line_Contract_Scan, Line_Contract_ScanPath, Line_Contract_Scanname);

                    int userid = ـauthHelper.CurrentAccountId();
                    result.Edit(command.Name, command.Company, command.Phone, command.Address, command.Id_Card,
                        Id_Card_Scan, Line_Contract_ScanId_Card_Scan, command.Start_Date, command.End_Date, Rent,
                        command.Money_Id, command.Shop_Id, userid);
                    _shop_For_RentRepository.SaveChanges();

                    var rent = _shopRepository.Get(command.Shop_Id);
                    rent.Edit(true, result.Id);
                    rent.Full(command.Start_Date);
                    rent.Edit(command.Start_Date);
                    _shopRepository.SaveChanges();

                    return operation.Succedded();
                }
            }
        }

        public Edit_ShopForRent GetDetails(int id)
        {
            return _shop_For_RentRepository.GetDetails(id);
        }

        public List<ViewModel_ShopForRent> GetViewModel()
        {
            return _shop_For_RentRepository.GetViewModel();
        }

        public Shop_For_RentPhoto GetPhoto(int id)
        {
            return _shop_For_RentRepository.GetPhoto(id);
        }

        public void Remove(int id)
        {
            var resalt = _shop_For_RentRepository.Get(id);
            resalt.Remove();
            _shop_For_RentRepository.SaveChanges();
        }

        public OperationResult Empty(Edit_ShopForRent command)
        {
            var operation = new OperationResult();
            var result = _shop_For_RentRepository.Get(command.Id);
            if (result == null)
            {
                return operation.Failed(ApplicationMessages.DuplicatedRecord);
            }
            else
            {
                int userid = ـauthHelper.CurrentAccountId();
                result.Edit(command.End_Date, userid);
                _shop_For_RentRepository.SaveChanges();

                var rent = _shopRepository.Get(command.Shop_Id);
                rent.Edit(false, 0);
                rent.Empty(command.End_Date);
                _shopRepository.SaveChanges();

                return operation.Succedded();
            }
        }

        public void Rest(int id, decimal rest)
        {
            var resalt = _shop_For_RentRepository.Get(id);
            resalt.Edit(rest);
            _shop_For_RentRepository.SaveChanges();
        }

        public OperationResult Total_Rest()
        {
            var operation = new OperationResult();

            var resalt = _shop_For_RentRepository.GetViewModel().Where(x => x.Status == true);
            if (resalt != null)
            {
                foreach (var item in resalt)
                {
                    decimal receipt = _receiptRentRepository.GetReceiptRent()
                        .Where(x => x.Status == true && x.ForRent_Id == item.Id).Sum(x => x.Shop_Amount);

                    decimal Month1 = _rentRepository.GetViewModel()
                        .Where(x => x.Status == true && x.Money_Id == item.Id_Money && x.ForRent_Id == item.Id).Sum(x => x.Month_1);
                    decimal Month2 = _rentRepository.GetViewModel()
                        .Where(x => x.Status == true && x.Money_Id == item.Id_Money && x.ForRent_Id == item.Id).Sum(x => x.Month_2);
                    decimal Month3 = _rentRepository.GetViewModel()
                        .Where(x => x.Status == true && x.Money_Id == item.Id_Money && x.ForRent_Id == item.Id).Sum(x => x.Month_3);
                    decimal Month4 = _rentRepository.GetViewModel()
                        .Where(x => x.Status == true && x.Money_Id == item.Id_Money && x.ForRent_Id == item.Id).Sum(x => x.Month_4);
                    decimal Month5 = _rentRepository.GetViewModel()
                        .Where(x => x.Status == true && x.Money_Id == item.Id_Money && x.ForRent_Id == item.Id).Sum(x => x.Month_5);
                    decimal Month6 = _rentRepository.GetViewModel()
                        .Where(x => x.Status == true && x.Money_Id == item.Id_Money && x.ForRent_Id == item.Id).Sum(x => x.Month_6);
                    decimal Month7 = _rentRepository.GetViewModel()
                        .Where(x => x.Status == true && x.Money_Id == item.Id_Money && x.ForRent_Id == item.Id).Sum(x => x.Month_7);
                    decimal Month8 = _rentRepository.GetViewModel()
                        .Where(x => x.Status == true && x.Money_Id == item.Id_Money && x.ForRent_Id == item.Id).Sum(x => x.Month_8);
                    decimal Month9 = _rentRepository.GetViewModel()
                        .Where(x => x.Status == true && x.Money_Id == item.Id_Money && x.ForRent_Id == item.Id).Sum(x => x.Month_9);
                    decimal Month10 = _rentRepository.GetViewModel()
                        .Where(x => x.Status == true && x.Money_Id == item.Id_Money && x.ForRent_Id == item.Id).Sum(x => x.Month_10);
                    decimal Month11 = _rentRepository.GetViewModel()
                        .Where(x => x.Status == true && x.Money_Id == item.Id_Money && x.ForRent_Id == item.Id).Sum(x => x.Month_11);
                    decimal Month12 = _rentRepository.GetViewModel()
                        .Where(x => x.Status == true && x.Money_Id == item.Id_Money && x.ForRent_Id == item.Id).Sum(x => x.Month_12);

                    decimal Months = Month1 + Month2 + Month3 + Month4 + Month5 + Month6 + Month7 + Month8 + Month9 + Month10 + Month11 + Month12;


                    decimal rent = Months - receipt;
                    var shopForRent = _shop_For_RentRepository.Get(item.Id);
                    shopForRent.Edit(rent);
                    _shop_For_RentRepository.SaveChanges();

                }
            }
            return operation.Succedded();
        }
    }
}