using _0_Framework.Application;
using _0_Framework.Infrastructure;
using AccountManagement.Application.Contracts.Electrical_System.Box_Meter.Meter;
using Domin.Electrical_System.Box_MeterAgg.MeterAgg;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Repository
{
    public class MeterRepository : RepositoryBase<int, Meter>, IMeterRepository
    {
        private readonly FM_Context _Context;

        public MeterRepository(FM_Context Context) : base(Context)
        {
            _Context = Context;
        }
        public MeterEdit GetDetails(int id)
        {
            return _Context.Meters.Select(x => new MeterEdit
            {
                Id = x.Id,
                Name = x.Name,
                BoxMeter_Id = x.BoxMeter_Id,
                Cod = x.Cod,
                Rest = x.Rest,
                Shop_Id = x.Shop_Id,
                Use = x.Use,
                Grade = x.Grade
            }).FirstOrDefault(x => x.Id == id);
        }
        public List<MeterViewModel> GetViewModel()
        {
            var users = _Context.Accounts.Select(x => new { x.Id, x.Username }).ToList();
            var BoxMeter = _Context.BoxMeters.Select(x => new { x.Id, x.Name }).ToList();
            var shop = _Context.Shops.Select(x => new { x.Id, x.Name, x.Location_Id }).ToList();
            var location = _Context.Locations.Select(x => new { x.Id, x.Name }).ToList();
            var query = _Context.Meters.Select(x => new MeterViewModel
            {
                Id = x.Id,
                Name = x.Name,
                BoxMeter_Id = x.BoxMeter_Id,
                Cod = x.Cod,
                Rest = x.Rest,
                Shop_Id = x.Shop_Id,
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
            result.ForEach(item =>
                item.Shop = shop.FirstOrDefault(x => x.Id == item.Shop_Id)?.Name);
            result.ForEach(item =>
                item.Location_Id = shop.FirstOrDefault(x => x.Id == item.Shop_Id).Location_Id);
            result.ForEach(item =>
                item.Location = location.FirstOrDefault(x => x.Id == item.Location_Id)?.Name);

            return result;
        }

    }
}