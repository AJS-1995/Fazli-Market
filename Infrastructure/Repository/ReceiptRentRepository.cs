using _0_Framework.Application;
using _0_Framework.Infrastructure;
using AccountManagement.Application.Contracts.ReceiptRent;
using Domin.ReceiptRentAgg;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Repository
{
    public class ReceiptRentRepository : RepositoryBase<int, ReceiptRent>, IReceiptRentRepository
    {
        private readonly FM_Context _context;

        public ReceiptRentRepository(FM_Context context) : base(context)
        {
            _context = context;
        }

        public ReceiptRentEdit GetDetails(int id)
        {
            return _context.ReceiptRents.Select(x => new ReceiptRentEdit()
            {
                Id = x.Id,
                Shop_Amount = x.Shop_Amount,
                By = x.By,
                ForRent_Id = x.ForRent_Id,
                Shop_Id = x.Shop_Id,
                PayBox_Id = x.PayBox_Id,
                Date = x.Date,
                Years = x.Years,
                Months = x.Months
            }).FirstOrDefault(x => x.Id == id);
        }

        public List<ReceiptRentViewModel> GetReceiptRent()
        {
            var users = _context.Accounts.Select(x => new { x.Id, x.Username }).ToList();
            var paybox = _context.PayBoxs.Select(x => new { x.Id, x.Name }).ToList();
            var location = _context.Locations.Select(x => new { x.Id, x.Name }).ToList();
            var shop = _context.Shops.Select(x => new { x.Id, x.Name, x.Location_Id }).ToList();
            var shopForRents = _context.Shop_For_Rents.Select(x => new { x.Id, x.Name, x.Company, x.Money_Id }).ToList();
            var money = _context.Moneys.Select(x => new { x.Id, x.Name }).ToList();
            var query = _context.ReceiptRents.Select(x => new ReceiptRentViewModel
            {
                Id = x.Id,
                Shop_Amount = x.Shop_Amount,
                By = x.By,
                ForRent_Id = x.ForRent_Id,
                Shop_Id = x.Shop_Id,
                PayBox_Id = x.PayBox_Id,
                User_Id = x.User_Id,
                CreationDate = x.CreationDate.ToFarsi(),
                Status = x.Status,
                Date = x.Date,
                Years = x.Years,
                Months = x.Months
            });
            var result = query.OrderByDescending(x => x.Id).ToList();

            result.ForEach(item => item.UserName = users.FirstOrDefault(x => x.Id == item.User_Id)?.Username);
            result.ForEach(item => item.PayBox = paybox.FirstOrDefault(x => x.Id == item.PayBox_Id)?.Name);
            result.ForEach(item => item.Shop = shop.FirstOrDefault(x => x.Id == item.Shop_Id)?.Name);
            result.ForEach(item => item.ForRentName = shopForRents.FirstOrDefault(x => x.Id == item.ForRent_Id)?.Name);
            result.ForEach(item => item.ForRentCompany = shopForRents.FirstOrDefault(x => x.Id == item.ForRent_Id)?.Company);
            result.ForEach(item => item.Location_Id = shop.FirstOrDefault(x => x.Id == item.Shop_Id).Location_Id);
            result.ForEach(item => item.Location = location.FirstOrDefault(x => x.Id == item.Location_Id)?.Name);
            result.ForEach(item => item.Money_Id = shopForRents.FirstOrDefault(x => x.Id == item.ForRent_Id).Money_Id);
            result.ForEach(item => item.Money = money.FirstOrDefault(x => x.Id == item.Money_Id)?.Name);

            return result;
        }
    }
}