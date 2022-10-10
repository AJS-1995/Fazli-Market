using _0_Framework.Application;
using AccountManagement.Application.Contracts.Electrical_System.Box_Meter.Meter;
using Domin.Electrical_System.Box_MeterAgg.MeterAgg;
using System.Collections.Generic;

namespace Application
{
    public class MOperationApplication : IMOperationApplication
    {
        private readonly IMeterRepository _meterRepository;
        private readonly IMOperationRepository _moperationRepository;
        private readonly IAuthHelper ـauthHelper;
        public MOperationApplication(IMeterRepository meterRepository, IAuthHelper ـauthHelper,
            IMOperationRepository moperationRepository)
        {
            _meterRepository = meterRepository;
            this.ـauthHelper = ـauthHelper;
            _moperationRepository = moperationRepository;
        }

        public void Activate(int id)
        {
            var operation = _moperationRepository.Get(id);
            operation.Activate();
            _moperationRepository.SaveChanges();
        }

        public OperationResult Create(MOperationCreate command)
        {
            var Operation = new OperationResult();
            if (_moperationRepository.Exists(x => x.Date_Rrad == command.Date_Rrad && x.Date_Pay == command.Date_Pay && x.Meter_Id == command.Meter_Id))
            {
                return Operation.Failed(ApplicationMessages.DuplicatedRecord);
            }
            else
            {
                int userid = ـauthHelper.CurrentAccountId();
                var operation = new MOperation(command.Meter_Id, command.Date_Rrad, command.Date_Pay, command.Grade_Past, command.Grade_Now,
                    command.Grade, command.Price, command.Complete, command.Other, command.Total, userid);
                _moperationRepository.Create(operation);
                _moperationRepository.SaveChanges();
                var grade = _meterRepository.Get(command.Meter_Id);
                grade.GradeEdit(command.Grade_Now);
                _meterRepository.SaveChanges();
                return Operation.Succedded();
            }
        }

        public OperationResult Edit(MOperationEdit command)
        {
            var operation = new OperationResult();
            var operationm = _moperationRepository.Get(command.Id);
            if (operationm == null)
            {
                return operation.Failed(ApplicationMessages.DuplicatedRecord);
            }
            else
            {
                if (_moperationRepository.Exists(x => x.Date_Rrad == command.Date_Rrad && x.Id != command.Id && x.Meter_Id == command.Meter_Id))
                {
                    return operation.Failed(ApplicationMessages.DuplicatedRecord);
                }
                else
                {
                    int userid = ـauthHelper.CurrentAccountId();
                    operationm.Edit(command.Meter_Id, command.Date_Rrad, command.Date_Pay, command.Grade_Past, command.Grade_Now,
                        command.Grade, command.Price, command.Complete, command.Other, command.Total, command.Rest, userid);
                    _moperationRepository.SaveChanges();
                    var grade = _meterRepository.Get(command.Meter_Id);
                    grade.GradeEdit(command.Grade_Now);
                    _meterRepository.SaveChanges();
                    return operation.Succedded();
                }
            }
        }

        public MOperationEdit GetDetails(int id)
        {
            return _moperationRepository.GetDetails(id);
        }

        public List<MOperationViewModel> GetOperation()
        {
            return _moperationRepository.GetOperation();
        }

        public void Remove(int id)
        {
            var operation = _moperationRepository.Get(id);
            operation.Remove();
            _moperationRepository.SaveChanges();
        }
    }
}