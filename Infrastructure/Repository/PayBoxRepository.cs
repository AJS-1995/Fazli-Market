using _0_Framework.Application;
using _0_Framework.Infrastructure;
using AccountManagement.Application.Contracts.PayBox;
using Domin.PayBoxAgg;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Repository
{
    public class PayBoxRepository : RepositoryBase<int, PayBox>, IPayBoxRepository
    {
        private readonly FM_Context _context;

        public PayBoxRepository(FM_Context context) : base(context)
        {
            _context = context;
        }

        public Edit_PayBox GetDetails(int id)
        {
            return _context.PayBoxs.Select(x => new Edit_PayBox()
            {
                Id = x.Id,
                Name = x.Name,
                Money_Id = x.Money_Id,
                Rest = x.Rest
            }).FirstOrDefault(x => x.Id == id);
        }

        public List<ViewModel_PayBox> GetViewModel()
        {
            var users = _context.Accounts.Select(x => new { x.Id, x.Username }).ToList();
            var moneys = _context.Moneys.Select(x => new { x.Id, x.Name }).ToList();
            var query = _context.PayBoxs.Select(x => new ViewModel_PayBox
            {
                Id = x.Id,
                Name = x.Name,
                CreationDate = x.CreationDate.ToFarsi(),
                Money_Id = x.Money_Id,
                Rest = x.Rest,
                User_Id = x.User_Id,
                Status = x.Status
            });
            var result = query.OrderByDescending(x => x.Id).ToList();

            result.ForEach(item =>
                item.UserName = users.FirstOrDefault(x => x.Id == item.User_Id)?.Username);

            result.ForEach(item =>
                item.Money = moneys.FirstOrDefault(x => x.Id == item.Money_Id)?.Name);

            return result;
        }
    }
}