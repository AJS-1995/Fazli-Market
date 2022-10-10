using _0_Framework.Application;
using AccountManagement.Application.Contracts.Sold;
using Domin.ShopAgg;
using Domin.SoldAgg;
using System.Collections.Generic;

namespace Application
{
    public class SoldApplication : ISoldApplication
    {
        private readonly ISoldRepository _soldRepository;
        private readonly IShop_Repository _shopRepository;
        private readonly IAuthHelper ـauthHelper;
        public SoldApplication(ISoldRepository soldRepository, IAuthHelper ـauthHelper, IShop_Repository shopRepository)
        {
            _soldRepository = soldRepository;
            this.ـauthHelper = ـauthHelper;
            _shopRepository = shopRepository;
        }
        public void Activate(int id)
        {
            var resalt = _soldRepository.Get(id);
            resalt.Activate();
            _soldRepository.SaveChanges();
        }

        public OperationResult Create(Create_Sold command)
        {
            var Operation = new OperationResult();
            if (_soldRepository.Exists(x => x.Name == command.Name && x.Shop_Id == command.Shop_Id))
            {
                return Operation.Failed(ApplicationMessages.DuplicatedRecord);
            }
            else
            {
                int userid = ـauthHelper.CurrentAccountId();
                var result = new Sold(command.Name, command.Company, command.Phone, command.Address, command.Start_Date, command.End_Date, command.Shop_Id, userid);
                _soldRepository.Create(result);
                _soldRepository.SaveChanges();

                var rent = _shopRepository.Get(command.Shop_Id);
                rent.Edit(true, result.Id);
                _shopRepository.SaveChanges();

                return Operation.Succedded();
            }
        }

        public OperationResult Edit(Edit_Sold command)
        {
            var operation = new OperationResult();
            var result = _soldRepository.Get(command.Id);
            if (result == null)
            {
                return operation.Failed(ApplicationMessages.DuplicatedRecord);
            }
            else
            {
                if (_soldRepository.Exists(x => x.Name == command.Name && x.Shop_Id == command.Shop_Id && x.Id != command.Id))
                {
                    return operation.Failed(ApplicationMessages.DuplicatedRecord);
                }
                else
                {
                    int userid = ـauthHelper.CurrentAccountId();
                    result.Edit(command.Name, command.Company, command.Phone, command.Address, command.Start_Date, command.End_Date, command.Shop_Id, userid);
                    _soldRepository.SaveChanges();

                    var rent = _shopRepository.Get(command.Shop_Id);
                    rent.Edit(true, result.Id);
                    _shopRepository.SaveChanges();

                    return operation.Succedded();
                }
            }
        }
        public Edit_Sold GetDetails(int id)
        {
            return _soldRepository.GetDetails(id);
        }
        public List<ViewModel_Sold> GetViewModel()
        {
            return _soldRepository.GetViewModel();
        }
        public void Remove(int id)
        {
            var resalt = _soldRepository.Get(id);
            resalt.Remove();
            _soldRepository.SaveChanges();
        }
        public OperationResult Empty(Edit_Sold command)
        {
            var operation = new OperationResult();
            var result = _soldRepository.Get(command.Id);
            if (result == null)
            {
                return operation.Failed(ApplicationMessages.DuplicatedRecord);
            }
            else
            {
                int userid = ـauthHelper.CurrentAccountId();
                result.Edit(command.End_Date, userid);
                _soldRepository.SaveChanges();

                var rent = _shopRepository.Get(command.Shop_Id);
                rent.Edit(0);
                _shopRepository.SaveChanges();

                return operation.Succedded();
            }
        }
    }
}