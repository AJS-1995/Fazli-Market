using _0_Framework.Application;
using _0_Framework.Infrastructure;
using AccountManagement.Application.Contracts.PayBox;
using Domin.PayBoxAgg;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Repository
{
    public class TransfersPayBoxRepository : RepositoryBase<int, TransfersPayBox>, ITransfersPayBoxRepository
    {
        private readonly FM_Context _context;

        public TransfersPayBoxRepository(FM_Context context) : base(context)
        {
            _context = context;
        }

        public Edit_TransfersPayBox GetDetails(int id)
        {
            return _context.TransfersPayBoxs.Select(x => new Edit_TransfersPayBox()
            {
                Id = x.Id,
                By = x.By,
                PayBoxIn_Id = x.PayBoxIn_Id,
                Amount = x.Amount,
                PayBoxTo_Id = x.PayBoxTo_Id,
                Money_Id = x.Money_Id,
                Date = x.Date,
            }).FirstOrDefault(x => x.Id == id);
        }

        public List<ViewModel_TransfersPayBox> GetViewModel()
        {
            var users = _context.Accounts.Select(x => new { x.Id, x.Username }).ToList();
            var moneys = _context.Moneys.Select(x => new { x.Id, x.Name }).ToList();
            var payboxs = _context.PayBoxs.Select(x => new { x.Id, x.Name }).ToList();
            var query = _context.TransfersPayBoxs.Select(x => new ViewModel_TransfersPayBox
            {
                Id = x.Id,
                CreationDate = x.CreationDate.ToFarsi(),
                By = x.By,
                PayBoxIn_Id = x.PayBoxIn_Id,
                Amount = x.Amount,
                PayBoxTo_Id = x.PayBoxTo_Id,
                Money_Id = x.Money_Id,
                User_Id = x.User_Id,
                Status = x.Status,
                Date = x.Date
            });
            var result = query.OrderByDescending(x => x.Id).ToList();

            result.ForEach(item =>
                item.UserName = users.FirstOrDefault(x => x.Id == item.User_Id)?.Username);

            result.ForEach(item =>
                item.Money = moneys.FirstOrDefault(x => x.Id == item.Money_Id)?.Name);

            result.ForEach(item =>
                item.PayBoxIn = payboxs.FirstOrDefault(x => x.Id == item.PayBoxIn_Id)?.Name);
            result.ForEach(item =>
                item.PayBoxTo = payboxs.FirstOrDefault(x => x.Id == item.PayBoxTo_Id)?.Name);

            return result;
        }
    }
}