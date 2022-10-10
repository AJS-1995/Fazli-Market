using _0_Framework.Application;
using _0_Framework.Infrastructure;
using AccountManagement.Application.Contracts.Electrical_System.General_Meter;
using Domin.Electrical_System.General_MeterAgg;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Repository
{
    public class PayRepository : RepositoryBase<int, Pay>, IPayRepository
    {
        private readonly FM_Context _context;
        public PayRepository(FM_Context context) : base(context)
        {
            _context = context;
        }

        public PayEdit GetDetails(int id)
        {
            return _context.Pays.Select(x => new PayEdit()
            {
                Id = x.Id,
                Amount = x.Amount,
                Date_Pay = x.Date_Pay,
                Operation_Id = x.Operation_Id,
                PayBox_Id = x.PayBox_Id,
                GeneralMeter_Id = x.GeneralMeter_Id
            }).FirstOrDefault(x => x.Id == id);
        }

        public List<PayViewModel> GetPay()
        {
            var users = _context.Accounts.Select(x => new { x.Id, x.Username }).ToList();
            var paybox = _context.PayBoxs.Select(x => new { x.Id, x.Name }).ToList();
            var operation = _context.Operations.Select(x => new { x.Id, x.Date_Rrad }).ToList();
            var query = _context.Pays.Select(x => new PayViewModel
            {
                Id = x.Id,
                Amount = x.Amount,
                Date_Pay = x.Date_Pay,
                CreationDate = x.CreationDate.ToFarsi(),
                Status = x.Status,
                Photo = x.Photo,
                User_Id = x.User_Id,
                Operation_Id = x.Operation_Id,
                PayBox_Id = x.PayBox_Id,
                GeneralMeter_Id = x.GeneralMeter_Id
            });
            var result = query.OrderByDescending(x => x.Id).ToList();

            result.ForEach(item =>
                item.UserName = users.FirstOrDefault(x => x.Id == item.User_Id)?.Username);

            result.ForEach(item => 
                item.PayBox = paybox.FirstOrDefault(x => x.Id == item.PayBox_Id)?.Name);

            result.ForEach(item =>
                item.Date_Rrad = operation.FirstOrDefault(x => x.Id == item.Operation_Id)?.Date_Rrad);

            return result;
        }
    }
}