using _0_Framework.Application;
using AccountManagement.Application.Contracts.Money;
using Domin.Moneys;
using System.Collections.Generic;

namespace Application
{
    public class MoneyApplication : IMoneyApplication 
    {
        private readonly IMoneyRepository _moneyRepository;
        private readonly IAuthHelper ـauthHelper;

        public string Date;
        public MoneyApplication(IMoneyRepository moneyRepository, IAuthHelper ـauthHelper)
        {
            _moneyRepository = moneyRepository;
            this.ـauthHelper = ـauthHelper;
        }
        public OperationResult Create(CreateMoney command)
        {
            var Operation = new OperationResult();
            if (_moneyRepository.Exists(x => x.Name == command.Name))
            {
                return Operation.Failed(ApplicationMessages.DuplicatedRecord);
            }
            else
            {
                int userid = ـauthHelper.CurrentAccountId();
                var money = new Money(command.Name, command.Country, command.Symbol, userid);
                _moneyRepository.Create(money);
                _moneyRepository.SaveChanges();
                return Operation.Succedded();
            }
        }

        public OperationResult Edit(MoneyEdit command)
        {
            var operation = new OperationResult();

            var money = _moneyRepository.Get(command.Id);
            if (money == null)
            {
                return operation.Failed(ApplicationMessages.DuplicatedRecord);
            }
            else
            {
                if (_moneyRepository.Exists(x => x.Name == command.Name && x.Id != command.Id))
                {
                    return operation.Failed(ApplicationMessages.DuplicatedRecord);
                }
                else
                {
                    int userid = ـauthHelper.CurrentAccountId();
                    money.Edit(command.Name, command.Country, command.Symbol, userid);
                    _moneyRepository.SaveChanges();
                    return operation.Succedded();
                }
            }
        }

        public MoneyEdit GetDetails(int id)
        {
            return _moneyRepository.GetDetails(id);
        }

        public List<MoneyViewModel> GetMoney()
        {
            return _moneyRepository.GetMoney();
        }
        public void Remove(int id)
        {
            var money = _moneyRepository.Get(id);
            money.Remove();
            _moneyRepository.SaveChanges();
        }

        public void Activate(int id)
        {
            var money = _moneyRepository.Get(id);
            money.Activate();
            _moneyRepository.SaveChanges();
        }
    }
}