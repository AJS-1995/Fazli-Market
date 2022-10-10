using _0_Framework.Application;
using AccountManagement.Application.Contracts.Electrical_System.Box_Meter;
using Domin.Electrical_System.Box_MeterAgg;
using System.Collections.Generic;

namespace Application
{
    public class BoxMeterApplication : IBoxMeterApplication
    {
        private readonly IBoxMeterRepository _boxMeterRepository;
        private readonly IAuthHelper ـauthHelper;
        public BoxMeterApplication(IBoxMeterRepository boxMeterRepository, IAuthHelper ـauthHelper)
        {
            _boxMeterRepository = boxMeterRepository;
            this.ـauthHelper = ـauthHelper;
        }

        public void Activate(int id)
        {
            var result = _boxMeterRepository.Get(id);
            result.Activate();
            _boxMeterRepository.SaveChanges();
        }

        public OperationResult Create(BoxMeterCreate command)
        {
            var Operation = new OperationResult();
            if (_boxMeterRepository.Exists(x => x.Name == command.Name))
            {
                return Operation.Failed(ApplicationMessages.DuplicatedRecord);
            }
            else
            {
                int userid = ـauthHelper.CurrentAccountId();
                var result = new BoxMeter(command.Name, userid);
                _boxMeterRepository.Create(result);
                _boxMeterRepository.SaveChanges();
                return Operation.Succedded();
            }
        }

        public OperationResult Edit(BoxMeterEdit command)
        {
            var operation = new OperationResult();
            var result = _boxMeterRepository.Get(command.Id);
            if (result == null)
            {
                return operation.Failed(ApplicationMessages.DuplicatedRecord);
            }
            else
            {
                if (_boxMeterRepository.Exists(x => x.Name == command.Name && x.Id != command.Id))
                {
                    return operation.Failed(ApplicationMessages.DuplicatedRecord);
                }
                else
                {
                    int userid = ـauthHelper.CurrentAccountId();
                    result.Edit(command.Name, userid);
                    _boxMeterRepository.SaveChanges();
                    return operation.Succedded();
                }
            }
        }

        public BoxMeterEdit GetDetails(int id)
        {
            return _boxMeterRepository.GetDetails(id);
        }

        public List<BoxMeterViewModel> GetViewModel()
        {
            return _boxMeterRepository.GetViewModel();
        }

        public void Remove(int id)
        {
            var result = _boxMeterRepository.Get(id);
            result.Remove();
            _boxMeterRepository.SaveChanges();
        }
    }
}