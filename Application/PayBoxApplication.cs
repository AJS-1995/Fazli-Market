using _0_Framework.Application;
using AccountManagement.Application.Contracts.PayBox;
using Domin.PayBoxAgg;
using System.Collections.Generic;

namespace Application
{
    public class PayBoxApplication : IPayBoxApplication
    {
        private readonly IPayBoxRepository _payBoxRepository;
        private readonly IAuthHelper ـauthHelper;
        public PayBoxApplication(IAuthHelper authHelper, IPayBoxRepository payBoxRepository)
        {
            ـauthHelper = authHelper;
            _payBoxRepository = payBoxRepository;
        }

        public void Activate(int id)
        {
            var result = _payBoxRepository.Get(id);
            result.Activate();
            _payBoxRepository.SaveChanges();
        }

        public OperationResult Create(PayBox_Create command)
        {
            var Operation = new OperationResult();
            if (_payBoxRepository.Exists(x => x.Name == command.Name && x.Money_Id ==command.Money_Id))
            {
                return Operation.Failed(ApplicationMessages.DuplicatedRecord);
            }
            else
            {
                int userid = ـauthHelper.CurrentAccountId();
                var result = new PayBox(command.Name, command.Money_Id, userid);
                _payBoxRepository.Create(result);
                _payBoxRepository.SaveChanges();
                return Operation.Succedded();
            }
        }

        public OperationResult Edit(Edit_PayBox command)
        {
            var operation = new OperationResult();
            var result = _payBoxRepository.Get(command.Id);
            if (result == null)
            {
                return operation.Failed(ApplicationMessages.DuplicatedRecord);
            }
            else
            {
                if (_payBoxRepository.Exists(x => x.Name == command.Name && x.Money_Id == command.Money_Id && x.Id != command.Id))
                {
                    return operation.Failed(ApplicationMessages.DuplicatedRecord);
                }
                else
                {
                    int userid = ـauthHelper.CurrentAccountId();
                    result.Edit(command.Name, command.Rest, command.Money_Id, userid);
                    _payBoxRepository.SaveChanges();
                    return operation.Succedded();
                }
            }
        }

        public Edit_PayBox GetDetails(int id)
        {
            return _payBoxRepository.GetDetails(id);
        }

        public List<ViewModel_PayBox> GetPayBox()
        {
            return _payBoxRepository.GetViewModel();
        }

        public void Remove(int id)
        {
            var result = _payBoxRepository.Get(id);
            result.Remove();
            _payBoxRepository.SaveChanges();
        }
    }
}