using _0_Framework.Application;
using _0_Framework.Infrastructure;
using AccountManagement.Application.Contracts.Electrical_System.Box_Meter.Meter;
using Domin.Electrical_System.Box_MeterAgg.MeterAgg;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Repository
{
    public class MPayRepository : RepositoryBase<int, MPay>, IMPayRepository
    {
        private readonly FM_Context _context;
        public MPayRepository(FM_Context context) : base(context)
        {
            _context = context;
        }

        public MPayEdit GetDetails(int id)
        {
            return _context.MPays.Select(x => new MPayEdit()
            {
                Id = x.Id,
                Amount = x.Amount,
                Date_Pay = x.Date_Pay,
                MOperation_Id = x.MOperation_Id,
                PayBox_Id = x.PayBox_Id,
                Meter_Id = x.Meter_Id
            }).FirstOrDefault(x => x.Id == id);
        }

        public List<MPayViewModel> GetMPay()
        {
            var users = _context.Accounts.Select(x => new { x.Id, x.Username }).ToList();
            var paybox = _context.PayBoxs.Select(x => new { x.Id, x.Name }).ToList();
            var operation = _context.MOperations.Select(x => new { x.Id, x.Date_Rrad }).ToList();
            var query = _context.MPays.Select(x => new MPayViewModel
            {
                Id = x.Id,
                Amount = x.Amount,
                Date_Pay = x.Date_Pay,
                CreationDate = x.CreationDate.ToFarsi(),
                Status = x.Status,
                Photo = x.Photo,
                User_Id = x.User_Id,
                MOperation_Id = x.MOperation_Id,
                PayBox_Id = x.PayBox_Id,
                Meter_Id = x.Meter_Id
            });
            var result = query.OrderByDescending(x => x.Id).ToList();

            result.ForEach(item =>
                item.UserName = users.FirstOrDefault(x => x.Id == item.User_Id)?.Username);

            result.ForEach(item =>
                item.PayBox = paybox.FirstOrDefault(x => x.Id == item.PayBox_Id)?.Name);

            result.ForEach(item => 
                item.Date_Rrad = operation.FirstOrDefault(x => x.Id == item.MOperation_Id)?.Date_Rrad);

            return result;
        }
    }
}