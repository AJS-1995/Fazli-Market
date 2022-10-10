using _0_Framework.Application;
using System.Collections.Generic;

namespace AccountManagement.Application.Contracts.Account
{
    public interface IAccountApplication
    {
        AccountViewModel GetAccountBy(int id);
        OperationResult Register(RegisterAccount command);
        OperationResult Edit(EditAccount command);
        OperationResult ChangePassword(ChangePassword command);
        OperationResult Login(Login command);
        EditAccount GetDetails(int id);
        void Logout();
        List<AccountViewModel> GetAccounts();
        void Remove(int id);
        void Activate(int id);
    }
}