using _0_Framework.Application;
using _0_Framework.Infrastructure;
using AccountManagement.Application.Contracts.Shop_For_Rent;
using Domin.Shop_For_RentAgg;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Repository
{
    public class ShopForRent_Repository : RepositoryBase<int, ShopForRent>, IShopForRentRepository
    {
        private readonly FM_Context _context;

        public ShopForRent_Repository(FM_Context context) : base(context)
        {
            _context = context;
        }
        public Edit_ShopForRent GetDetails(int id)
        {
            return _context.Shop_For_Rents.Select(x => new Edit_ShopForRent()
            {
                Id = x.Id,
                Name = x.Name,
                Address = x.Address,
                Company=x.Company,
                End_Date = x.End_Date,
                Id_Card=x.Id_Card,
                Phone=x.Phone,
                Rent = x.Rent,
                Start_Date = x.Start_Date,
                Money_Id = x.Money_Id,
                Shop_Id = x.Shop_Id,
                Card_Scan = x.Id_Card_Scan,
                Contract_Scan = x.Line_Contract_Scan,
                Rest = x.Rest,
            }).FirstOrDefault(x => x.Id == id);
        }
        public Shop_For_RentPhoto GetPhoto(int id)
        {
            return _context.Shop_For_Rents
                .Where(x => x.Id == id)
                .Select(x => new Shop_For_RentPhoto
                {
                    Id = x.Id,
                    Id_Card_Scan = x.Id_Card_Scan,
                    Line_Contract_Scan = x.Line_Contract_Scan
                }).FirstOrDefault(x => x.Id == id);
        }
        public List<ViewModel_ShopForRent> GetViewModel()
        {
            var moneys = _context.Moneys.Select(x => new { x.Id, x.Name }).ToList();
            var users = _context.Accounts.Select(x => new { x.Id, x.Username }).ToList();
            var shops = _context.Shops.Select(x => new { x.Id, x.Location_Id, x.Name }).ToList();
            var location = _context.Locations.Select(x => new { x.Id, x.Name }).ToList();
            var query = _context.Shop_For_Rents.Select(x => new ViewModel_ShopForRent
            {
                Id = x.Id,
                Name = x.Name,
                Address = x.Address,
                Company = x.Company,
                End_Date = x.End_Date,
                Id_Card = x.Id_Card,
                Phone = x.Phone,
                Rent = x.Rent,
                Start_Date = x.Start_Date,
                Id_Card_Scan = x.Id_Card_Scan,
                Line_Contract_Scan = x.Line_Contract_Scan,
                Status = x.Status,
                Id_Shop = x.Shop_Id,
                Id_Money = x.Money_Id,
                CreationDate = x.CreationDate.ToFarsi(),
                User_Id = x.User_Id,
                Rest = x.Rest,
            });
            var Shop_For_Rent = query.OrderByDescending(x => x.Id).ToList();

            Shop_For_Rent.ForEach(item =>
                item.Money = moneys.FirstOrDefault(x => x.Id == item.Id_Money)?.Name);

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