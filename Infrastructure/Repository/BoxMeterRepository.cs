using _0_Framework.Application;
using _0_Framework.Infrastructure;
using AccountManagement.Application.Contracts.Electrical_System.Box_Meter;
using Domin.Electrical_System.Box_MeterAgg;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Repository
{
    public class BoxMeterRepository : RepositoryBase<int, BoxMeter>, IBoxMeterRepository
    {
        private readonly FM_Context _context;
        public BoxMeterRepository(FM_Context context) : base(context)
        {
            _context = context;
        }

        public BoxMeterEdit GetDetails(int id)
        {
            return _context.BoxMeters.Select(x => new BoxMeterEdit()
            {
                Id = x.Id,
                Name = x.Name
            }).FirstOrDefault(x => x.Id == id);
        }

        public List<BoxMeterViewModel> GetViewModel()
        {
            var users = _context.Accounts.Select(x => new { x.Id, x.Username }).ToList();
            var query = _context.BoxMeters.Select(x => new BoxMeterViewModel
            {
                Id = x.Id,
                Name = x.Name,
                CreationDate = x.CreationDate.ToFarsi(),
                Status = x.Status,
                User_Id = x.User_Id
            });

            var result = query.OrderByDescending(x => x.Id).ToList();

            result.ForEach(item =>
                item.UserName = users.FirstOrDefault(x => x.Id == item.User_Id)?.Username);

            return result;
        }
    }
}