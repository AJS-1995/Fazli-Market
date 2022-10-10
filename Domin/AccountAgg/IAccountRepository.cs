using _0_Framework.Domain;
using AccountManagement.Application.Contracts.Account;
using System.Collections.Generic;

namespace Domin.AccountAgg
{
    public interface IAccountRepository : IRepository<int, Account>
    {
        Account GetBy(string username);
        EditAccount GetDetails(int id);
        List<AccountViewModel> GetAccounts();
    }
}
