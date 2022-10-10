using _0_Framework.Application;
using _0_Framework.Infrastructure;
using AccountManagement.Application.Contracts.ExSlaRec;
using Domin.ExSlaRecAgg;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Repository
{
    public class ExSlaRecRepository : RepositoryBase<int, ExSlaRec>, IExSlaRecRepository
    {
        private readonly FM_Context _context;

        public ExSlaRecRepository(FM_Context context) : base(context)
        {
            _context = context;
        }
        public ExSlaRecEdit GetDetails(int id)
        {
            return _context.ExSlaRecs.Select(x => new ExSlaRecEdit()
            {
                Id = x.Id,
                Date = x.Date,
                Description = x.Description,
                Amount = x.Amount,
                Type = x.Type,
                By = x.By,
                Money_Id = x.Money_Id,
                Employee_Id = x.Employee_Id,
                PayBox_Id = x.PayBox_Id
            }).FirstOrDefault(x => x.Id == id);
        }

        public List<ExSlaRecViewModel> GetExSlaRec()
        {
            var users = _context.Accounts.Select(x => new { x.Id, x.Username }).ToList();
            var money = _context.Moneys.Select(x => new { x.Id, x.Name }).ToList();
            var employees = _context.Employees.Select(x => new { x.Id, x.FullName }).ToList();
            var paybox = _context.PayBoxs.Select(x => new { x.Id, x.Name }).ToList();
            var query = _context.ExSlaRecs.Select(x => new ExSlaRecViewModel
            {
                Id = x.Id,
                Date = x.Date,
                Description = x.Description,
                Amount = x.Amount,
                Type = x.Type,
                By = x.By,
                Money_Id = x.Money_Id,
                Employee_Id = x.Employee_Id,
                PayBox_Id = x.PayBox_Id,
                CreationDate = x.CreationDate.ToFarsi(),
                Status = x.Status,
                User_Id = x.User_Id
            });

            var result = query.OrderByDescending(x => x.Id).ToList();

            result.ForEach(item =>
                item.UserName = users.FirstOrDefault(x => x.Id == item.User_Id)?.Username);

            result.ForEach(item =>
                item.Money = money.FirstOrDefault(x => x.Id == item.Money_Id)?.Name);

            result.ForEach(item => 
                item.Employee = employees.FirstOrDefault(x => x.Id == item.Employee_Id)?.FullName);

            result.ForEach(item =>
                item.PayBox = paybox.FirstOrDefault(x => x.Id == item.PayBox_Id)?.Name);
            return result;
        }
    }
}