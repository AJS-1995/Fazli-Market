using _0_Framework.Application;
using AccountManagement.Application.Contracts.PayBox;
using Domin.PayBoxAgg;
using System.Collections.Generic;

namespace Application
{
    public class TransfersPayBoxApplication : ITransfersPayBoxApplication
    {
        private readonly ITransfersPayBoxRepository _transfersPayBoxRepository;
        private readonly IAuthHelper ـauthHelper;
        public TransfersPayBoxApplication(IAuthHelper authHelper, ITransfersPayBoxRepository transfersPayBoxRepository)
        {
            ـauthHelper = authHelper;
            _transfersPayBoxRepository = transfersPayBoxRepository;
        }

        public void Activate(int id)
        {
            var result = _transfersPayBoxRepository.Get(id);
            result.Activate();
            _transfersPayBoxRepository.SaveChanges();
        }

        public OperationResult Create(TransfersPayBox_Create command)
        {
            var Operation = new OperationResult();
            int userid = ـauthHelper.CurrentAccountId();
            var result = new TransfersPayBox(command.PayBoxIn_Id, command.PayBoxTo_Id, command.By, command.Amount, command.Date,
                command.Money_Id, userid);
            _transfersPayBoxRepository.Create(result);
            _transfersPayBoxRepository.SaveChanges();
            return Operation.Succedded();
        }

        public OperationResult Edit(Edit_TransfersPayBox command)
        {
            var operation = new OperationResult();
            var result = _transfersPayBoxRepository.Get(command.Id);
            if (result == null)
            {
                return operation.Failed(ApplicationMessages.DuplicatedRecord);
            }
            else
            {
                int userid = ـauthHelper.CurrentAccountId();
                result.Edit(command.PayBoxIn_Id, command.PayBoxTo_Id, command.By, command.Amount, command.Date, 
                    command.Money_Id, userid);
                _transfersPayBoxRepository.SaveChanges();
                return operation.Succedded();
            }
        }

        public Edit_TransfersPayBox GetDetails(int id)
        {
            return _transfersPayBoxRepository.GetDetails(id);
        }

        public List<ViewModel_TransfersPayBox> GetTransfersPayBox()
        {
            return _transfersPayBoxRepository.GetViewModel();
        }

        public void Remove(int id)
        {
            var result = _transfersPayBoxRepository.Get(id);
            result.Remove();
            _transfersPayBoxRepository.SaveChanges();
        }
    }
}