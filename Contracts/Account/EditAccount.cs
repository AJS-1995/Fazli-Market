using AccountManagement.Application.Contracts.Account;

namespace AccountManagement.Application.Contracts.Account
{
    public class EditAccount : RegisterAccount
    {
        public int Id { get; set; }
        public bool Status { get; set; }
    }
}
