using _0_Framework.Application;
using AccountManagement.Application.Contracts.Electrical_System.General_Meter;
using Domin.Electrical_System.General_MeterAgg;
using System.Collections.Generic;
using System.Linq;

namespace Application
{
    public class GeneralMeterApplication : IGeneralMeterApplication
    {
        private readonly IGeneralMeterRepository _generalMeterRepository;
        private readonly IOperationRepository _operationRepository;
        private readonly IPayRepository _payRepository;
        private readonly IAuthHelper ـauthHelper;
        public GeneralMeterApplication(IGeneralMeterRepository generalMeterRepository, IAuthHelper ـauthHelper, IOperationRepository operationRepository, IPayRepository payRepository)
        {
            _generalMeterRepository = generalMeterRepository;
            this.ـauthHelper = ـauthHelper;
            _operationRepository = operationRepository;
            _payRepository = payRepository;
        }

        public void Activate(int id)
        {
            var generalMeter = _generalMeterRepository.Get(id);
            generalMeter.Activate();
            _generalMeterRepository.SaveChanges();
        }

        public OperationResult Create(GeneralMeterCreate command)
        {
            var Operation = new OperationResult();
            if (_generalMeterRepository.Exists(x => x.Name == command.Name && x.Cod == command.Cod))
            {
                return Operation.Failed(ApplicationMessages.DuplicatedRecord);
            }
            else
            {
                int userid = ـauthHelper.CurrentAccountId();
                var generalMeter = new GeneralMeter(command.Name, command.Cod, command.Grade, command.Date, userid);
                _generalMeterRepository.Create(generalMeter);
                _generalMeterRepository.SaveChanges();
                return Operation.Succedded();
            }
        }

        public OperationResult Edit(GeneralMeterEdit command)
        {
            var operation = new OperationResult();
            var generalMeter = _generalMeterRepository.Get(command.Id);
            if (generalMeter == null)
            {
                return operation.Failed(ApplicationMessages.DuplicatedRecord);
            }
            else
            {
                if (_generalMeterRepository.Exists(x => x.Name == command.Name &&x.Cod == command.Cod && x.Id != command.Id))
                {
                    return operation.Failed(ApplicationMessages.DuplicatedRecord);
                }
                else
                {
                    int userid = ـauthHelper.CurrentAccountId();
                    generalMeter.Edit(command.Name, command.Cod, command.Grade, command.Date, userid);
                    _generalMeterRepository.SaveChanges();
                    return operation.Succedded();
                }
            }
        }

        public GeneralMeterEdit GetDetails(int id)
        {
            return _generalMeterRepository.GetDetails(id);
        }

        public List<GeneralMeterViewModel> GetGeneralMeter()
        {
            return _generalMeterRepository.GetGeneralMeter();
        }

        public void Remove(int id)
        {
            var generalMeter = _generalMeterRepository.Get(id);
            generalMeter.Remove();
            _generalMeterRepository.SaveChanges();
        }

        public OperationResult Total_Rest()
        {
            var operation = new OperationResult();

            var generalMeters = _generalMeterRepository.GetGeneralMeter();
            foreach (var item in generalMeters)
            {
                decimal rest = _operationRepository.GetOperation()
                        .Where(x => x.Status == true && x.GeneralMeter_Id == item.Id).Sum(x => x.Amount);

                decimal debt = _payRepository.GetPay()
                        .Where(x => x.Status == true && x.GeneralMeter_Id == item.Id).Sum(x => x.Amount);

                decimal total = rest - debt;

                var generalMeter = _generalMeterRepository.Get(item.Id);
                generalMeter.Edit(total);
                _generalMeterRepository.SaveChanges();
            }

            return operation.Succedded();
        }
    }
}