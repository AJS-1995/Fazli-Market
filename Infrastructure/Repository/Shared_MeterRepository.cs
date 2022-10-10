using _0_Framework.Application;
using _0_Framework.Infrastructure;
using AccountManagement.Application.Contracts.Electrical_System.Shared_Meter;
using Domin.Electrical_System.Shared_MeterAgg;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Repository
{
    public class Shared_MeterRepository : RepositoryBase<int, Shared_Meter>, ISharedMeterRepository
    {
        private readonly FM_Context _Context;

        public Shared_MeterRepository(FM_Context Context) : base(Context)
        {
            _Context = Context;
        }
        public Shared_MeterEdit GetDetails(int id)
        {
            return _Context.Shared_Meters.Select(x => new Shared_MeterEdit
            {
                Id = x.Id,
                Name = x.Name,
                BoxMeter_Id = x.BoxMeter_Id,
                Cod = x.Cod,
                Rest = x.Rest,
                Use = x.Use,
                Grade = x.Grade
            }).FirstOrDefault(x => x.Id == id);
        }
        public List<Shared_MeterViewModel> GetViewModel()
        {
            var users = _Context.Accounts.Select(x => new { x.Id, x.Username }).ToList();
            var BoxMeter = _Context.BoxMeters.Select(x => new { x.Id, x.Name }).ToList();
            var query = _Context.Shared_Meters.Select(x => new Shared_MeterViewModel
            {
                Id = x.Id,
                Name = x.Name,
                BoxMeter_Id = x.BoxMeter_Id,
                Cod = x.Cod,
                Rest = x.Rest,
                Use = x.Use,
                User_Id = x.User_Id,
                Status = x.Status,
                CreationDate = x.CreationDate.ToFarsi(),
                Grade = x.Grade
            });

            var result = query.OrderByDescending(x => x.Id).ToList();

            result.ForEach(item =>
                item.UserName = users.FirstOrDefault(x => x.Id == item.User_Id)?.Username);

            result.ForEach(item =>
                item.BoxMeter = BoxMeter.FirstOrDefault(x => x.Id == item.BoxMeter_Id)?.Name);

            return result;
        }

    }
}