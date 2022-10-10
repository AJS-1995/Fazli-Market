using _0_Framework.Application;
using _0_Framework.Infrastructure;
using AccountManagement.Application.Contracts.Inventory;
using Domin.InventoryAgg;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Repository
{
    public class InventoryRepository : RepositoryBase<int, Inventory>, IInventoryRepository
    {
        private readonly FM_Context _context;
        public InventoryRepository(FM_Context context) : base(context)
        {
            _context = context;
        }
        public InventoryEdit GetDetails(int id)
        {
            return _context.Inventorys.Select(x => new InventoryEdit
            {
                Id = x.Id,
                Name = x.Name,
                Location = x.Location
            }).FirstOrDefault(x => x.Id == id);
        }

        public List<InventoryViewModel> GetInventory()
        {
            var users = _context.Accounts.Select(x => new { x.Id, x.Username }).ToList();
            var query = _context.Inventorys.Select(x => new InventoryViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Location = x.Location,
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