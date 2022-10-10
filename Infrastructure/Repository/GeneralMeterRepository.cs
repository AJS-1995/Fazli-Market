using _0_Framework.Application;
using _0_Framework.Infrastructure;
using AccountManagement.Application.Contracts.Electrical_System.General_Meter;
using Domin.Electrical_System.General_MeterAgg;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Repository
{
    public class GeneralMeterRepository : RepositoryBase<int, GeneralMeter>, IGeneralMeterRepository
    {
        private readonly FM_Context _context;
        public GeneralMeterRepository(FM_Context context) : base(context)
        {
            _context = context;
        }

        public GeneralMeterEdit GetDetails(int id)
        {
            return _context.GeneralMeters.Select(x => new GeneralMeterEdit()
            {
                Id = x.Id,
                Cod = x.Cod,
                Name = x.Name,
                Date = x.Date,
                Grade = x.Grade
            }).FirstOrDefault(x => x.Id == id);
        }

        public List<GeneralMeterViewModel> GetGeneralMeter()
        {
            var users = _context.Accounts.Select(x => new { x.Id, x.Username }).ToList();
            var query = _context.GeneralMeters.Select(x => new GeneralMeterViewModel
            {
                Id = x.Id,
                Cod = x.Cod,
                Name = x.Name,
                CreationDate = x.CreationDate.ToFarsi(),
                Status = x.Status,
                User_Id = x.User_Id,
                Rest = x.Rest,
                Date = x.Date,
                Grade = x.Grade
            });
            var result = query.OrderByDescending(x => x.Id).ToList();

            result.ForEach(item =>
                item.UserName = users.FirstOrDefault(x => x.Id == item.User_Id)?.Username);

            return result;
        }
    }
}