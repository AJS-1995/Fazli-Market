using _0_Framework.Application;
using AccountManagement.Application.Contracts.Electrical_System.Shared_Meter;
using Domin.Electrical_System.Shared_MeterAgg;
using System.Collections.Generic;
using System.Linq;

namespace Application
{
    public class Shared_MeterApplication : IShared_MeterApplication
    {
        private readonly ISharedMeterRepository _sharedMeterRepository;
        private readonly IMSOperationRepository _msoperationRepository;
        private readonly IAuthHelper ـauthHelper;
        public Shared_MeterApplication(ISharedMeterRepository sharedMeterRepository, IAuthHelper authHelper, IMSOperationRepository msoperationRepository)
        {
            _sharedMeterRepository = sharedMeterRepository;
            ـauthHelper = authHelper;
            _msoperationRepository = msoperationRepository;
        }
        public OperationResult Create(Shared_MeterCreate command)
        {
            var operation = new OperationResult();
            if (_sharedMeterRepository.Exists(x => x.BoxMeter_Id == command.BoxMeter_Id && x.Name == command.Name))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);

            int userid = ـauthHelper.CurrentAccountId();
            var result = new Shared_Meter(command.BoxMeter_Id, command.Name, command.Cod, command.Use, command.Grade,
                userid);
            _sharedMeterRepository.Create(result);
            _sharedMeterRepository.SaveChanges();
            return operation.Succedded();
        }

        public OperationResult Edit(Shared_MeterEdit command)
        {
            var operation = new OperationResult();
            var result = _sharedMeterRepository.Get(command.Id);
            if (result == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);

            if (_sharedMeterRepository.Exists(x => x.BoxMeter_Id == command.BoxMeter_Id && x.Name == command.Name && x.Id != command.Id))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);

            int userid = ـauthHelper.CurrentAccountId();
            result.Edit(command.BoxMeter_Id, command.Name, command.Cod, command.Use, command.Grade, userid);
            _sharedMeterRepository.SaveChanges();
            return operation.Succedded();
        }

        public Shared_MeterEdit GetDetails(int id)
        {
            return _sharedMeterRepository.GetDetails(id);
        }
        public List<Shared_MeterViewModel> GetViewModel()
        {
            return _sharedMeterRepository.GetViewModel();
        }
        public void Remove(int id)
        {
            var money = _sharedMeterRepository.Get(id);
            money.Remove();
            _sharedMeterRepository.SaveChanges();
        }

        public void Activate(int id)
        {
            var money = _sharedMeterRepository.Get(id);
            money.Activate();
            _sharedMeterRepository.SaveChanges();
        }

        public OperationResult Total_Rest()
        {
            var operation = new OperationResult();

            var generalMeters = _sharedMeterRepository.GetViewModel();
            foreach (var item in generalMeters)
            {
                decimal rest = _msoperationRepository.GetOperation()
                        .Where(x => x.Status == true && x.Meter_Id == item.Id).Sum(x => x.Total);

                var generalMeter = _sharedMeterRepository.Get(item.Id);
                generalMeter.Edit(rest);
                _sharedMeterRepository.SaveChanges();
            }

            return operation.Succedded();
        }
    }
}