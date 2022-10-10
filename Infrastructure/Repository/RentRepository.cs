using _0_Framework.Infrastructure;
using AccountManagement.Application.Contracts.Rent;
using Domin.RentAgg;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Repository
{
    public class RentRepository : RepositoryBase<int, Rent>, IRentRepository
    {
        private readonly FM_Context _context;

        public RentRepository(FM_Context accountContext) : base(accountContext)
        {
            _context = accountContext;
        }

        public RentEdit GetDetails(int id)
        {
            return _context.Rents.Select(x => new RentEdit
            {
                Id = x.Id,
                Money_Id = x.Money_Id,
                Month_1 = x.Month_1,
                Month_2 = x.Month_2,
                Month_3 = x.Month_3,
                Month_4 = x.Month_4,
                Month_5 = x.Month_5,
                Month_6 = x.Month_6,
                Month_7 = x.Month_7,
                Month_8 = x.Month_8,
                Month_9 = x.Month_9,
                Month_10 = x.Month_10,
                Month_11 = x.Month_11,
                Month_12 = x.Month_12,
                Shop_Id = x.Shop_Id,
                Year = x.Year,
                ForRent_Id = x.ForRent_Id
            }).FirstOrDefault(x => x.Id == id);
        }

        public RentEdit Get_Id(int Shop_Id, int Money_Id, int ForRent_Id)
        {
            return _context.Rents.Select(x => new RentEdit
            {
                Id = x.Id,
                Money_Id = x.Money_Id,
                Month_1 = x.Month_1,
                Month_2 = x.Month_2,
                Month_3 = x.Month_3,
                Month_4 = x.Month_4,
                Month_5 = x.Month_5,
                Month_6 = x.Month_6,
                Month_7 = x.Month_7,
                Month_8 = x.Month_8,
                Month_9 = x.Month_9,
                Month_10 = x.Month_10,
                Month_11 = x.Month_11,
                Month_12 = x.Month_12,
                Shop_Id = x.Shop_Id,
                Year = x.Year,
                ForRent_Id = x.ForRent_Id
            }).FirstOrDefault(x => x.Shop_Id == Shop_Id && x.Money_Id == Money_Id && x.ForRent_Id == ForRent_Id);
        }

        public List<RentViewModel> GetViewModel()
        {
            var money = _context.Moneys.Select(x => new { x.Id, x.Name }).ToList();
            var shop = _context.Shops.Select(x => new { x.Id, x.Name, x.Location_Id }).ToList();
            var forrent = _context.Shop_For_Rents.Select(x => new { x.Id, x.Name, x.Company }).ToList();
            var location = _context.Locations.Select(x => new { x.Id, x.Name }).ToList();
            var query = _context.Rents.Select(x => new RentViewModel
            {
                Id = x.Id,
                Money_Id = x.Money_Id,
                Month_1 = x.Month_1,
                Month_2 = x.Month_2,
                Month_3 = x.Month_3,
                Month_4 = x.Month_4,
                Month_5 = x.Month_5,
                Month_6 = x.Month_6,
                Month_7 = x.Month_7,
                Month_8 = x.Month_8,
                Month_9 = x.Month_9,
                Month_10 = x.Month_10,
                Month_11 = x.Month_11,
                Month_12 = x.Month_12,
                Shop_Id = x.Shop_Id,
                Year = x.Year,
                ForRent_Id = x.ForRent_Id,
                Status = x.Status,
            });
            var result = query.OrderByDescending(x => x.Id).ToList();

            result.ForEach(item => item.Money = money.FirstOrDefault(x => x.Id == item.Money_Id)?.Name);

            result.ForEach(item => item.Shop = shop.FirstOrDefault(x => x.Id == item.Shop_Id)?.Name);
            result.ForEach(item => item.Location_Id = shop.FirstOrDefault(x => x.Id == item.Shop_Id).Location_Id);
            result.ForEach(item => item.Location = location.FirstOrDefault(x => x.Id == item.Location_Id)?.Name);

            result.ForEach(item => item.ForRentName = forrent.FirstOrDefault(x => x.Id == item.ForRent_Id)?.Name);
            result.ForEach(item => item.ForRentCompany = forrent.FirstOrDefault(x => x.Id == item.ForRent_Id)?.Company);

            return result;
        }
    }
}