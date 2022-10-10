using _0_Framework.Application;
using _0_Framework.Infrastructure;
using AccountManagement.Application.Contracts.Account;
using Domin.AccountAgg;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Repository
{
    public class AccountRepository : RepositoryBase<int, Account>, IAccountRepository
    {
        private readonly FM_Context _context;

        public AccountRepository(FM_Context context) : base(context)
        {
            _context = context;
        }

        public Account GetBy(string username)
        {
            return _context.Accounts.FirstOrDefault(x => x.Username == username);
        }

        public EditAccount GetDetails(int id)
        {
            return _context.Accounts.Select(x => new EditAccount
            {
                Id = x.Id,
                Fullname = x.Fullname,
                Mobile = x.Mobile,
                RoleId = x.RoleId,
                Username = x.Username
            }).FirstOrDefault(x => x.Id == id);
        }

        public List<AccountViewModel> GetAccounts()
        {
            var rols = _context.Roles.Select(x => new { x.Id, x.Name }).ToList();
            var query = _context.Accounts.Select(x => new AccountViewModel
            {
                Id = x.Id,
                Fullname = x.Fullname,
                CreationDate = x.CreationDate.ToFarsi(),
                Mobile = x.Mobile,
                ProfilePhoto = x.ProfilePhoto,
                RoleId = x.RoleId,
                Username = x.Username,
                Status = x.Status
            });
            var result = query.OrderByDescending(x => x.Id).ToList();

            result.ForEach(item => item.Role = rols.FirstOrDefault(x => x.Id == item.RoleId)?.Name);
            return result;
        }
    }
}