using _0_Framework.Application;
using System.Collections.Generic;

namespace AccountManagement.Application.Contracts.Money
{
    public interface IMoneyApplication
    {
        OperationResult Create(CreateMoney command);
        OperationResult Edit(MoneyEdit command);
        MoneyEdit GetDetails(int id);
        List<MoneyViewModel> GetMoney();
        void Remove(int id);
        void Activate(int id);
    }
}
