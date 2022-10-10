using _0_Framework.Application;
using _0_Framework.Infrastructure;
using AccountManagement.Application.Contracts.Money;
using Domin.Moneys;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Repository
{
    public class MoneyRepository : RepositoryBase<int, Money>, IMoneyRepository
    {
        private readonly FM_Context _context;

        public MoneyRepository(FM_Context context) : base(context)
        {
            _context = context;
        }

        public MoneyEdit GetDetails(int id)
        {
            return _context.Moneys.Select(x => new MoneyEdit()
            {
                Id = x.Id,
                Name = x.Name,
                Country = x.Country,
                Symbol = x.Symbol
            }).FirstOrDefault(x => x.Id == id);
        }

        public List<MoneyViewModel> GetMoney()
        {
            var users = _context.Accounts.Select(x => new { x.Id, x.Username }).ToList();
            var query = _context.Moneys.Select(x => new MoneyViewModel
            {
                Id = x.Id,
                Name = x.Name,
                CreationDate = x.CreationDate.ToFarsi(),
                Symbol = x.Symbol,
                Country = x.Country,
                Status = x.Status
            });
            var result = query.OrderByDescending(x => x.Id).ToList();

            result.ForEach(item =>
                item.UserName = users.FirstOrDefault(x => x.Id == item.User_Id)?.Username);

            return result;
        }
    }
}