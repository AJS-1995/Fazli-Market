using _0_Framework.Application;
using AccountManagement.Application.Contracts.Electrical_System.General_Meter;
using Domin.Electrical_System.General_MeterAgg;
using System.Collections.Generic;

namespace Application
{
    public class OperationApplication : IOperationApplication
    {
        private readonly IOperationRepository _operationRepository;
        private readonly IGeneralMeterRepository _generalMeterRepository;
        private readonly IAuthHelper ـauthHelper;
        private readonly IFileUploader _fileUploader;
        public OperationApplication(IAuthHelper ـauthHelper, IOperationRepository operationRepository, IFileUploader fileUploader, IGeneralMeterRepository generalMeterRepository)
        {
            this.ـauthHelper = ـauthHelper;
            _operationRepository = operationRepository;
            _fileUploader = fileUploader;
            _generalMeterRepository = generalMeterRepository;
        }

        public void Activate(int id)
        {
            var operation = _operationRepository.Get(id);
            operation.Activate();
            _operationRepository.SaveChanges();
        }

        public OperationResult Create(OperationCreate command)
        {
            var Operation = new OperationResult();
            if (_operationRepository.Exists(x => x.Date_Rrad == command.Date_Rrad && x.Date_Pay == command.Date_Pay))
            {
                return Operation.Failed(ApplicationMessages.DuplicatedRecord);
            }
            else
            {
                var Path = "Operation";
                var name = command.Date_Rrad.Slugify();
                var picturePath = _fileUploader.Upload(command.Photo, Path, name);

                int userid = ـauthHelper.CurrentAccountId();
                var operation = new Operation(command.GeneralMeter_Id, command.Date_Rrad, command.Date_Pay, command.Grade_Past,
                        command.Grade_Now, command.Amount, picturePath, userid);
                _operationRepository.Create(operation);
                _operationRepository.SaveChanges();
                var meter = _generalMeterRepository.Get(command.GeneralMeter_Id);
                meter.GradeEdit(command.Grade_Now);
                _generalMeterRepository.SaveChanges();
                return Operation.Succedded();
            }
        }

        public OperationResult Edit(OperationEdit command)
        {
            var operation = new OperationResult();
            var operationm = _operationRepository.Get(command.Id);
            if (operationm == null)
            {
                return operation.Failed(ApplicationMessages.DuplicatedRecord);
            }
            else
            {
                if (_operationRepository.Exists(x => x.Date_Rrad == command.Date_Rrad && x.Id != command.Id))
                {
                    return operation.Failed(ApplicationMessages.DuplicatedRecord);
                }
                else
                {
                    var Path = "Operation";
                    var name = command.Date_Rrad.Slugify();
                    var picturePath = _fileUploader.Upload(command.Photo, Path, name);

                    int userid = ـauthHelper.CurrentAccountId();
                    operationm.Edit(command.GeneralMeter_Id, command.Date_Rrad, command.Date_Pay, command.Grade_Past,
                        command.Grade_Now, command.Amount, command.Rest, picturePath, userid);
                    _operationRepository.SaveChanges();
                    var meter = _generalMeterRepository.Get(command.GeneralMeter_Id);
                    meter.GradeEdit(command.Grade_Now);
                    _generalMeterRepository.SaveChanges();
                    return operation.Succedded();
                }
            }
        }

        public OperationEdit GetDetails(int id)
        {
            return _operationRepository.GetDetails(id);
        }

        public List<OperationViewModel> GetOperation()
        {
            return _operationRepository.GetOperation();
        }

        public void Remove(int id)
        {
            var operation = _operationRepository.Get(id);
            operation.Remove();
            _operationRepository.SaveChanges();
        }
    }
}