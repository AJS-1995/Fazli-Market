using _0_Framework.Application;
using AccountManagement.Application.Contracts.Electrical_System.Box_Meter.Meter;
using Domin.Electrical_System.Box_MeterAgg.MeterAgg;
using Domin.ShopAgg;
using System.Collections.Generic;
using System.Linq;

namespace Application
{
    public class MeterApplication : IMeterApplication
    {
        private readonly IMeterRepository _meterRepository;
        private readonly IShop_Repository _shop_Repository;
        private readonly IMOperationRepository _moperationRepository;
        private readonly IMPayRepository _mPayRepository;
        private readonly IAuthHelper ـauthHelper;
        public MeterApplication(IMeterRepository meterRepository, IAuthHelper authHelper, IMOperationRepository moperationRepository, IShop_Repository shop_Repository, IMPayRepository mPayRepository)
        {
            _meterRepository = meterRepository;
            ـauthHelper = authHelper;
            _moperationRepository = moperationRepository;
            _shop_Repository = shop_Repository;
            _mPayRepository = mPayRepository;
        }
        public OperationResult Create(MeterCreate command)
        {
            var operation = new OperationResult();
            if (_meterRepository.Exists(x => x.BoxMeter_Id == command.BoxMeter_Id && x.Name == command.Name))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);

            int userid = ـauthHelper.CurrentAccountId();
            var result = new Meter(command.BoxMeter_Id, command.Name, command.Cod, command.Use, command.Shop_Id, command.Grade,
                userid);
            _meterRepository.Create(result);
            _meterRepository.SaveChanges();
            var shop = _shop_Repository.Get(command.Shop_Id);
            shop.Edit(true);
            _shop_Repository.SaveChanges();
            return operation.Succedded();
        }

        public OperationResult Edit(MeterEdit command)
        {
            var operation = new OperationResult();
            var result = _meterRepository.Get(command.Id);
            if (result == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);

            if (_meterRepository.Exists(x => x.BoxMeter_Id == command.BoxMeter_Id && x.Name == command.Name && x.Id != command.Id))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);

            int userid = ـauthHelper.CurrentAccountId();
            result.Edit(command.BoxMeter_Id, command.Name, command.Cod, command.Use, command.Shop_Id, command.Grade, userid);
            _meterRepository.SaveChanges();
            var shop = _shop_Repository.Get(command.Shop_Id);
            shop.Edit(true);
            _shop_Repository.SaveChanges();
            return operation.Succedded();
        }

        public MeterEdit GetDetails(int id)
        {
            return _meterRepository.GetDetails(id);
        }
        public List<MeterViewModel> GetViewModel()
        {
            return _meterRepository.GetViewModel();
        }
        public void Remove(int id)
        {
            var money = _meterRepository.Get(id);
            money.Remove();
            _meterRepository.SaveChanges();
        }

        public void Activate(int id)
        {
            var money = _meterRepository.Get(id);
            money.Activate();
            _meterRepository.SaveChanges();
        }

        public OperationResult Total_Rest()
        {
            var operation = new OperationResult();

            var generalMeters = _meterRepository.GetViewModel();
            foreach (var item in generalMeters)
            {
                decimal opera = _moperationRepository.GetOperation()
                        .Where(x => x.Status == true && x.Meter_Id == item.Id).Sum(x => x.Total);
                decimal pay = _mPayRepository.GetMPay()
                        .Where(x => x.Status == true && x.Meter_Id == item.Id).Sum(x => x.Amount);

                decimal totel = opera - pay;

                var generalMeter = _meterRepository.Get(item.Id);
                generalMeter.Edit(totel);
                _meterRepository.SaveChanges();
            }

            return operation.Succedded();
        }
    }
}