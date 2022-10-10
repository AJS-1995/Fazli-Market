using _0_Framework.Application;
using _0_Framework.Infrastructure;
using AccountManagement.Application.Contracts.Locations;
using Domin.Locations;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Repository
{
    public class Location_Repository : RepositoryBase<int, Location>, ILocation_Repository
    {
        private readonly FM_Context _context;
        public Location_Repository(FM_Context context) : base(context)
        {
            _context = context;
        }

        public Edit_Location GetDetails(int id)
        {
            return _context.Locations.Select(x => new Edit_Location()
            {
                Id = x.Id,
                Name = x.Name
            }).FirstOrDefault(x => x.Id == id);
        }

        public List<ViewModel_Location> GetViewModel()
        {
            var users = _context.Accounts.Select(x => new { x.Id, x.Username }).ToList();
            var query = _context.Locations.Select(x => new ViewModel_Location
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