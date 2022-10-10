using _0_Framework.Application;
using _0_Framework.Infrastructure;
using AccountManagement.Application.Contracts.Electrical_System.Shared_Meter;
using Domin.Electrical_System.Shared_MeterAgg;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Repository
{
    public class MSOperationRepository : RepositoryBase<int, MSOperation>, IMSOperationRepository
    {
        private readonly FM_Context _context;
        public MSOperationRepository(FM_Context context) : base(context)
        {
            _context = context;
        }

        public MSOperationEdit GetDetails(int id)
        {
            return _context.MSOperations.Select(x => new MSOperationEdit()
            {
                Id = x.Id,
                Date_Pay = x.Date_Pay,
                Date_Rrad = x.Date_Rrad,
                Grade_Now = x.Grade_Now,
                Grade_Past = x.Grade_Past,
                Grade = x.Grade,
                Meter_Id = x.Meter_Id,
                Price = x.Price,
                Total = x.Total,
                Rest = (int)x.Rest
            }).FirstOrDefault(x => x.Id == id);
        }

        public List<MSOperationViewModel> GetOperation()
        {
            var users = _context.Accounts.Select(x => new { x.Id, x.Username }).ToList();
            var meters = _context.Shared_Meters.Select(x => new { x.Id, x.Name }).ToList();
            var query = _context.MSOperations.Select(x => new MSOperationViewModel
            {
                Id = x.Id,
                Date_Pay = x.Date_Pay,
                Date_Rrad = x.Date_Rrad,
                Grade_Now = x.Grade_Now,
                Grade_Past = x.Grade_Past,
                Total = x.Total,
                Grade = x.Grade,
                Meter_Id = x.Meter_Id,
                Price = x.Price,
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