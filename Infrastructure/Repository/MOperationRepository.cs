using _0_Framework.Application;
using _0_Framework.Infrastructure;
using AccountManagement.Application.Contracts.Electrical_System.Box_Meter.Meter;
using Domin.Electrical_System.Box_MeterAgg.MeterAgg;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Repository
{
    public class MOperationRepository : RepositoryBase<int, MOperation>, IMOperationRepository
    {
        private readonly FM_Context _context;
        public MOperationRepository(FM_Context context) : base(context)
        {
            _context = context;
        }

        public MOperationEdit GetDetails(int id)
        {
            return _context.MOperations.Select(x => new MOperationEdit()
            {
                Id = x.Id,
                Date_Pay = x.Date_Pay,
                Date_Rrad = x.Date_Rrad,
                Grade_Now = x.Grade_Now,
                Grade_Past = x.Grade_Past,
                Complete = x.Complete,
                Grade = x.Grade,
                Meter_Id = x.Meter_Id,
                Other = x.Other,
                Price = x.Price,
                Total = x.Total,
                Rest = (int)x.Rest
            }).FirstOrDefault(x => x.Id == id);
        }

        public List<MOperationViewModel> GetOperation()
        {
            var users = _context.Accounts.Select(x => new { x.Id, x.Username }).ToList();
            var meters = _context.Meters.Select(x => new { x.Id, x.Name }).ToList();
            var query = _context.MOperations.Select(x => new MOperationViewModel
            {
                Id = x.Id,
                Date_Pay = x.Date_Pay,
                Date_Rrad = x.Date_Rrad,
                Grade_Now = x.Grade_Now,
                Grade_Past = x.Grade_Past,
                Complete = x.Complete,
                Grade = x.Grade,
                Meter_Id = x.Meter_Id,
                Other = x.Other,
                Price = x.Price,
                Total = x.Total,
                CreationDate = x.CreationDate.ToFarsi(),
                Status = x.Status,
                User_Id = x.User_Id,
                Rest = x.Rest
            });
            var result = query.OrderByDescending(x => x.Id).ToList();

            result.ForEach(item =>
                item.UserName = users.FirstOrDefault(x => x.Id == item.User_Id)?.Username);

            result.ForEach(item =>
                item.Meter = meters.FirstOrDefault(x => x.Id == item.Meter_Id)?.Name);

            return result;
        }
    }
}