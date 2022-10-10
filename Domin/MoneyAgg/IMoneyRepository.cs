using _0_Framework.Domain;
using AccountManagement.Application.Contracts.Money;
using System.Collections.Generic;

namespace Domin.Moneys
{
    public interface IMoneyRepository : IRepository<int, Money>
    {
        List<MoneyViewModel> GetMoney();
        MoneyEdit GetDetails(int id);
    }
}
