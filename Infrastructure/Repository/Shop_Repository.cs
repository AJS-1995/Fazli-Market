using _0_Framework.Application;
using _0_Framework.Infrastructure;
using AccountManagement.Application.Contracts.Shop;
using Domin.ShopAgg;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Repository
{
    public class Shop_Repository : RepositoryBase<int, Shop>, IShop_Repository
    {
        private readonly FM_Context _Context;

        public Shop_Repository(FM_Context Context) : base(Context)
        {
            _Context = Context;
        }
        public Edit_Shop GetDetails(int id)
        {
            return _Context.Shops.Select(x => new Edit_Shop
            {
                Id = x.Id,
                Location_Id = x.Location_Id,
                Name = x.Name,
                Id_Shopkeeper = x.Id_Shopkeeper,
                Sold = x.Sold
            }).FirstOrDefault(x => x.Id == id);
        }

        public List<ViewModel_Locations> GetLocations(int Location_Id)
        {
            return _Context.Shops
                .Where(x=> x.Location_Id == Location_Id)
                .Select(x => new ViewModel_Locations
                {
                Id = x.Id,
                Name = x.Name,
                Rent = x.Rent,
                Meter = x.Meter,
                Sold = x.Sold
            }).ToList();
        }
        public List<ViewModel_Shop> GetShop()
        {
            var users = _Context.Accounts.Select(x => new { x.Id, x.Username }).ToList();
            var locations = _Context.Locations.Select(x => new { x.Id, x.Name }).ToList();
            var forrent = _Context.Shop_For_Rents.Select(x => new { x.Id, x.Name, x.Company, x.Rent, x.Rest, x.Money_Id }).ToList();
            var query = _Context.Shops.Select(x => new ViewModel_Shop
            {
                Id = x.Id,
                Location_Id = x.Location_Id,
                Name = x.Name,
                Rent = x.Rent,
                User_Id = x.User_Id,
                Status = x.Status,
                CreationDate = x.CreationDate.ToFarsi(),
                Id_Shopkeeper = x.Id_Shopkeeper,
                Start_Date = x.Start_Date,
                End_Date = x.End_Date,
                Date = x.Date,
                Sold = x.Sold,
                Rest = x.Rest
            });

            var result = query.OrderByDescending(x => x.Id).ToList();

            result.ForEach(item => item.UserName = users.FirstOrDefault(x => x.Id == item.User_Id)?.Username);
            result.ForEach(item => item.Location = locations.FirstOrDefault(x => x.Id == item.Location_Id)?.Name);
            result.ForEach(item => item.ForRentName = forrent.FirstOrDefault(x => x.Id == item.Id_Shopkeeper)?.Name);
            result.ForEach(item => item.ForRentCompany = forrent.FirstOrDefault(x => x.Id == item.Id_Shopkeeper)?.Company);
            result.ForEach(item => item.ForRentRest = forrent.FirstOrDefault(x => x.Id == item.Id_Shopkeeper)?.Rest.ToString());
            result.ForEach(item => item.ForRentRent = forrent.FirstOrDefault(x => x.Id == item.Id_Shopkeeper)?.Rent.ToString());
            return result;
        }
    }
}