using _0_Framework.Application;
using _0_Framework.Infrastructure;
using AccountManagement.Application.Contracts.Sold;
using Domin.SoldAgg;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Repository
{
    public class SoldRepository : RepositoryBase<int, Sold>, ISoldRepository
    {
        private readonly FM_Context _context;

        public SoldRepository(FM_Context context) : base(context)
        {
            _context = context;
        }
        public Edit_Sold GetDetails(int id)
        {
            return _context.Solds.Select(x => new Edit_Sold()
            {
                Id = x.Id,
                Name = x.Name,
                Address = x.Address,
                Company=x.Company,
                End_Date = x.End_Date,
                Phone=x.Phone,
                Start_Date = x.Start_Date,
                Shop_Id = x.Shop_Id,
            }).FirstOrDefault(x => x.Id == id);
        }
        public List<ViewModel_Sold> GetViewModel()
        {
            var users = _context.Accounts.Select(x => new { x.Id, x.Username }).ToList();
            var shops = _context.Shops.Select(x => new { x.Id, x.Location_Id, x.Name }).ToList();
            var location = _context.Locations.Select(x => new { x.Id, x.Name }).ToList();
            var query = _context.Solds.Select(x => new ViewModel_Sold
            {
                Id = x.Id,
                Name = x.Name,
                Address = x.Address,
                Company = x.Company,
                End_Date = x.End_Date,
                Phone = x.Phone,
                Start_Date = x.Start_Date,
                Status = x.Status,
                Id_Shop = x.Shop_Id,
                CreationDate = x.CreationDate.ToFarsi(),
                User_Id = x.User_Id,
            });
            var Shop_For_Rent = query.OrderByDescending(x => x.Id).ToList();

            Shop_For_Rent.ForEach(item =>
                item.UserName = users.FirstOrDefault(x => x.Id == item.User_Id)?.Username);

            Shop_For_Rent.ForEach(item =>
                item.Shop = shops.FirstOrDefault(x => x.Id == item.Id_Shop)?.Name);

            Shop_For_Rent.ForEach(item =>
                item.Location_Id = shops.FirstOrDefault(x => x.Id == item.Id_Shop)?.Location_Id.ToString());

            Shop_For_Rent.ForEach(item =>
                item.Location = location.FirstOrDefault(x => x.Id == int.Parse(item.Location_Id))?.Name);

            return Shop_For_Rent;
        }
    }
}