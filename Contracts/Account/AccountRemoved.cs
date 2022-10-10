using System.Collections.Generic;

namespace AccountManagement.Application.Contracts.Account
{
    public class AccountRemoved
    {
        public int Id { get; set; }
        public List<AccountViewModel> Accounts { get; set; }
    }
}
