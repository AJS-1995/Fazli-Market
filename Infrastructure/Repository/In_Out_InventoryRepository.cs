using _0_Framework.Application;
using _0_Framework.Infrastructure;
using AccountManagement.Application.Contracts.In_Out_Inventory;
using Domin.In_Out_InventoryAgg;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Repository
{
    public class In_Out_InventoryRepository : RepositoryBase<int, In_Out_Inventory>, IIn_Out_InventoryRepository
    {
        private readonly FM_Context _context;

        public In_Out_InventoryRepository(FM_Context context) : base(context)
        {
            _context = context;
        }

        public In_Out_InventoryEdit GetDetails(int id)
        {
            return _context.In_Out_Inventorys.Select(x => new In_Out_InventoryEdit()
            {
                Id = x.Id,
                Date = x.Date,
                Details = x.Details,
                Amount = x.Amount,
                By = x.By,
                MoneyId = x.MoneyId,
                InventoryId = x.InventoryId,
                UserId = x.User_Id,
                Sum = x.Sum,
                Type = x.Type
            }).FirstOrDefault(x => x.Id == id);
        }

        public List<In_Out_InventoryViewModel> GetIn_Out_Inventory()
        {
            var moneys = _context.Moneys.Select(x => new { x.Id, x.Name }).ToList();
            var users = _context.Accounts.Select(x => new { x.Id, x.Username }).ToList();
            var inventory = _context.Inventorys.Select(x => new { x.Id, x.Name }).ToList();
            var query = _context.In_Out_Inventorys.Select(x => new In_Out_InventoryViewModel
                {
                    Id = x.Id,
                    Date = x.Date,
                    Details = x.Details,
                    Amount = x.Amount,
                    By = x.By,
                    MoneyId = x.MoneyId,
                    InventoryId = x.InventoryId,
                    User_Id = x.User_Id,
                    Sum = x.Sum,
                    CreationDate = x.CreationDate.ToFarsi(),
                    Status = x.Status,
                    Type = x.Type,
                    Ph_Invoice = x.Ph_Invoice
                });
            var result = query.OrderByDescending(x => x.Id).ToList();

            result.ForEach(item =>
                item.Money = moneys.FirstOrDefault(x => x.Id == item.MoneyId)?.Name);

            result.ForEach(item =>
                item.UserName = users.FirstOrDefault(x => x.Id == item.User_Id)?.Username);

            result.ForEach(item =>
                item.Inventory = inventory.FirstOrDefault(x => x.Id == item.InventoryId)?.Name);

            return result;
        }
        public In_Out_InventoryPhoto GetPhoto(int id)
        {
            return _context.In_Out_Inventorys
                .Where(x => x.Id == id)
                .Select(x => new In_Out_InventoryPhoto
                {
                    Id = x.Id,
                    Ph_Invoice = x.Ph_Invoice
                }).FirstOrDefault(x => x.Id == id);
        }
    }
}