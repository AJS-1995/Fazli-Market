using _0_Framework.Application;
using _0_Framework.Infrastructure;
using AccountManagement.Application.Contracts.Sla_Rec;
using Domin.Sla_RecAgg;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Repository
{
    public class Sla_RecRepository : RepositoryBase<int, SlaRec>, ISla_RecRepository
    {
        private readonly FM_Context _context;

        public Sla_RecRepository(FM_Context context) : base(context)
        {
            _context = context;
        }
        public Sla_RecEdit GetDetails(int id)
        {
            return _context.SlaRecs.Select(x => new Sla_RecEdit()
            {
                Id = x.Id,
                Date = x.Date,
                Description = x.Description,
                Amount = x.Amount,
                N_Invoice = x.N_Invoice,
                Type = x.Type,
                By = x.By,
                Money_Id = x.Money_Id,
                Person_Id = x.Person_Id,
                PayBox_Id = x.PayBox_Id
            }).FirstOrDefault(x => x.Id == id);
        }

        public List<Sla_RecViewModel> GetSla_Rec()
        {
            var users = _context.Accounts.Select(x => new { x.Id, x.Username }).ToList();
            var money = _context.Moneys.Select(x => new { x.Id, x.Name }).ToList();
            var person = _context.Persons.Select(x => new { x.Id, x.Name }).ToList();
            var paybox = _context.PayBoxs.Select(x => new { x.Id, x.Name }).ToList();
            var query = _context.SlaRecs.Select(x => new Sla_RecViewModel
            {
                Id = x.Id,
                Date = x.Date,
                Description = x.Description,
                Amount = x.Amount,
                N_Invoice = x.N_Invoice,
                Type = x.Type,
                By = x.By,
                Money_Id = x.Money_Id,
                Person_Id = x.Person_Id,
                PayBox_Id = x.PayBox_Id,
                CreationDate = x.CreationDate.ToFarsi(),
                Status = x.Status,
                User_Id = x.User_Id
            });

            var result = query.OrderByDescending(x => x.Id).ToList();

            result.ForEach(item =>
                item.UserName = users.FirstOrDefault(x => x.Id == item.User_Id)?.Username);

            result.ForEach(item =>
                item.Money = money.FirstOrDefault(x => x.Id == item.Money_Id)?.Name);

            result.ForEach(item => 
                item.Person = person.FirstOrDefault(x => x.Id == item.Person_Id)?.Name);

            result.ForEach(item =>
                item.PayBox = paybox.FirstOrDefault(x => x.Id == item.PayBox_Id)?.Name);
            return result;
        }
    }
}