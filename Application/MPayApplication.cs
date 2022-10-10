using _0_Framework.Application;
using AccountManagement.Application.Contracts.Electrical_System.Box_Meter.Meter;
using Domin.Electrical_System.Box_MeterAgg.MeterAgg;
using System.Collections.Generic;

namespace Application
{
    public class MPayApplication : IMPayApplication
    {
        private readonly IMPayRepository _mpayRepository;
        private readonly IAuthHelper ـauthHelper;
        private readonly IFileUploader _fileUploader;
        public MPayApplication(IAuthHelper ـauthHelper, IMPayRepository mpayRepository, IFileUploader fileUploader)
        {
            this.ـauthHelper = ـauthHelper;
            _mpayRepository = mpayRepository;
            _fileUploader = fileUploader;
        }

        public void Activate(int id)
        {
            var operation = _mpayRepository.Get(id);
            operation.Activate();
            _mpayRepository.SaveChanges();
        }

        public OperationResult Create(MPayCreate command)
        {
            var Operation = new OperationResult();
            var Path = "MPay";
            var name = command.Date_Pay.Slugify();
            var picturePath = _fileUploader.Upload(command.Photo, Path, name);

            int userid = ـauthHelper.CurrentAccountId();
            var mpay = new MPay(command.Meter_Id, command.MOperation_Id, command.PayBox_Id, command.Date_Pay, command.Amount, picturePath, userid);
            _mpayRepository.Create(mpay);
            _mpayRepository.SaveChanges();
            return Operation.Succedded();
        }

        public OperationResult Edit(MPayEdit command)
        {
            var operation = new OperationResult();
            var MPay = _mpayRepository.Get(command.Id);
            if (MPay == null)
            {
                return operation.Failed(ApplicationMessages.DuplicatedRecord);
            }
            else
            {
                var Path = "MPay";
                var name = command.Date_Pay.Slugify();
                var picturePath = _fileUploader.Upload(command.Photo, Path, name);

                int userid = ـauthHelper.CurrentAccountId();
                MPay.Edit(command.Meter_Id, command.MOperation_Id, command.PayBox_Id, command.Date_Pay, command.Amount, picturePath, userid);
                _mpayRepository.SaveChanges();
                return operation.Succedded();
            }
        }

        public MPayEdit GetDetails(int id)
        {
            return _mpayRepository.GetDetails(id);
        }

        public List<MPayViewModel> GetMPay()
        {
            return _mpayRepository.GetMPay();
        }

        public void Remove(int id)
        {
            var operation = _mpayRepository.Get(id);
            operation.Remove();
            _mpayRepository.SaveChanges();
        }
    }
}