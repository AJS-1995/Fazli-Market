using _0_Framework.Application;
using AccountManagement.Application.Contracts.Electrical_System.General_Meter;
using Domin.Electrical_System.General_MeterAgg;
using System.Collections.Generic;

namespace Application
{
    public class PayApplication : IPayApplication
    {
        private readonly IPayRepository _payRepository;
        private readonly IAuthHelper ـauthHelper;
        private readonly IFileUploader _fileUploader;
        public PayApplication(IAuthHelper ـauthHelper, IPayRepository payRepository, IFileUploader fileUploader)
        {
            this.ـauthHelper = ـauthHelper;
            _payRepository = payRepository;
            _fileUploader = fileUploader;
        }

        public void Activate(int id)
        {
            var operation = _payRepository.Get(id);
            operation.Activate();
            _payRepository.SaveChanges();
        }

        public OperationResult Create(PayCreate command)
        {
            var Operation = new OperationResult();
            if (_payRepository.Exists(x => x.Date_Pay == command.Date_Pay))
            {
                return Operation.Failed(ApplicationMessages.DuplicatedRecord);
            }
            else
            {
                var Path = "Pay";
                var name = command.Date_Pay.Slugify();
                var picturePath = _fileUploader.Upload(command.Photo, Path, name);

                int userid = ـauthHelper.CurrentAccountId();
                var pay = new Pay(command.GeneralMeter_Id, command.Operation_Id, command.PayBox_Id, command.Date_Pay, command.Amount, picturePath, userid);
                _payRepository.Create(pay);
                _payRepository.SaveChanges();
                return Operation.Succedded();
            }
        }

        public OperationResult Edit(PayEdit command)
        {
            var operation = new OperationResult();
            var Pay = _payRepository.Get(command.Id);
            if (Pay == null)
            {
                return operation.Failed(ApplicationMessages.DuplicatedRecord);
            }
            else
            {
                if (_payRepository.Exists(x => x.Date_Pay == command.Date_Pay && x.Id != command.Id))
                {
                    return operation.Failed(ApplicationMessages.DuplicatedRecord);
                }
                else
                {
                    var Path = "Pay";
                    var name = command.Date_Pay.Slugify();
                    var picturePath = _fileUploader.Upload(command.Photo, Path, name);

                    int userid = ـauthHelper.CurrentAccountId();
                    Pay.Edit(command.GeneralMeter_Id, command.Operation_Id, command.PayBox_Id, command.Date_Pay, command.Amount, picturePath, userid);
                    _payRepository.SaveChanges();
                    return operation.Succedded();
                }
            }
        }

        public PayEdit GetDetails(int id)
        {
            return _payRepository.GetDetails(id);
        }

        public List<PayViewModel> GetPay()
        {
            return _payRepository.GetPay();
        }

        public void Remove(int id)
        {
            var operation = _payRepository.Get(id);
            operation.Remove();
            _payRepository.SaveChanges();
        }
    }
}