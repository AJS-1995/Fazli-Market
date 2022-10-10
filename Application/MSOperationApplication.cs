using _0_Framework.Application;
using AccountManagement.Application.Contracts.Electrical_System.Shared_Meter;
using Domin.Electrical_System.Shared_MeterAgg;
using System.Collections.Generic;

namespace Application
{
    public class MSOperationApplication : IMSOperationApplication
    {
        private readonly ISharedMeterRepository _sharedMeterRepository;
        private readonly IMSOperationRepository _msoperationRepository;
        private readonly IAuthHelper ـauthHelper;
        public MSOperationApplication(ISharedMeterRepository sharedMeterRepository, IAuthHelper ـauthHelper, IMSOperationRepository msoperationRepository)
        {
            _sharedMeterRepository = sharedMeterRepository;
            this.ـauthHelper = ـauthHelper;
            _msoperationRepository = msoperationRepository;
        }

        public void Activate(int id)
        {
            var operation = _msoperationRepository.Get(id);
            operation.Activate();
            _msoperationRepository.SaveChanges();
        }

        public OperationResult Create(MSOperationCreate command)
        {
            var Operation = new OperationResult();
            if (_msoperationRepository.Exists(x => x.Date_Rrad == command.Date_Rrad && x.Date_Pay == command.Date_Pay && x.Meter_Id == command.Meter_Id))
            {
                return Operation.Failed(ApplicationMessages.DuplicatedRecord);
            }
            else
            {
                int userid = ـauthHelper.CurrentAccountId();
                var operation = new MSOperation(command.Meter_Id, command.Date_Rrad, command.Date_Pay, command.Grade_Past, command.Grade_Now,
                    command.Grade, command.Price, command.Total, userid);
                _msoperationRepository.Create(operation);
                _msoperationRepository.SaveChanges();
                var grade = _sharedMeterRepository.Get(command.Meter_Id);
                grade.GradeEdit(command.Grade_Now);
                _msoperationRepository.SaveChanges();
                return Operation.Succedded();
            }
        }

        public OperationResult Edit(MSOperationEdit command)
        {
            var operation = new OperationResult();
            var operationm = _msoperationRepository.Get(command.Id);
            if (operationm == null)
            {
                return operation.Failed(ApplicationMessages.DuplicatedRecord);
            }
            else
            {
                if (_msoperationRepository.Exists(x => x.Date_Rrad == command.Date_Rrad && x.Id != command.Id && x.Meter_Id == command.Meter_Id))
                {
                    return operation.Failed(ApplicationMessages.DuplicatedRecord);
                }
                else
                {
                    int userid = ـauthHelper.CurrentAccountId();
                    operationm.Edit(command.Meter_Id, command.Date_Rrad, command.Date_Pay, command.Grade_Past, command.Grade_Now,
                        command.Grade, command.Price, command.Total, command.Rest, userid);
                    _msoperationRepository.SaveChanges();
                    var grade = _sharedMeterRepository.Get(command.Meter_Id);
                    grade.GradeEdit(command.Grade_Now);
                    _sharedMeterRepository.SaveChanges();
                    return operation.Succedded();
                }
            }
        }

        public MSOperationEdit GetDetails(int id)
        {
            return _msoperationRepository.GetDetails(id);
        }

        public List<MSOperationViewModel> GetOperation()
        {
            return _msoperationRepository.GetOperation();
        }

        public void Remove(int id)
        {
            var operation = _msoperationRepository.Get(id);
            operation.Remove();
            _msoperationRepository.SaveChanges();
        }
    }
}