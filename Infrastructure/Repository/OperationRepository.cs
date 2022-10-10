using _0_Framework.Application;
using _0_Framework.Infrastructure;
using AccountManagement.Application.Contracts.Electrical_System.General_Meter;
using Domin.Electrical_System.General_MeterAgg;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Repository
{
    public class OperationRepository : RepositoryBase<int, Operation>, IOperationRepository
    {
        private readonly FM_Context _context;
        public OperationRepository(FM_Context context) : base(context)
        {
            _context = context;
        }

        public OperationEdit GetDetails(int id)
        {
            return _context.Operations.Select(x => new OperationEdit()
            {
                Id = x.Id,
                Amount = x.Amount,
                Date_Pay = x.Date_Pay,
                Date_Rrad = x.Date_Rrad,
                GeneralMeter_Id = x.GeneralMeter_Id,
                Grade_Now = x.Grade_Now,
                Grade_Past = x.Grade_Past,
                Rest = x.Rest
            }).FirstOrDefault(x => x.Id == id);
        }

        public List<OperationViewModel> GetOperation()
        {
            var users = _context.Accounts.Select(x => new { x.Id, x.Username }).ToList();
            var generalmeters = _context.GeneralMeters.Select(x => new { x.Id, x.Name }).ToList();
            var query = _context.Operations.Select(x => new OperationViewModel
            {
                Id = x.Id,
                Amount = x.Amount,
                Date_Pay = x.Date_Pay,
                Date_Rrad = x.Date_Rrad,
                GeneralMeter_Id = x.GeneralMeter_Id,
                Grade_Now = x.Grade_Now,
                Grade_Past = x.Grade_Past,
                CreationDate = x.CreationDate.ToFarsi(),
                Status = x.Status,
                Photo = x.Photo,
                User_Id = x.User_Id,
                Rest = x.Rest,
            });
            var result = query.OrderByDescending(x => x.Id).ToList();

            result.ForEach(item =>
                item.UserName = users.FirstOrDefault(x => x.Id == item.User_Id)?.Username);

            result.ForEach(item =>
                item.GeneralMeter = generalmeters.FirstOrDefault(x => x.Id == item.GeneralMeter_Id)?.Name);

            return result;
        }
    }
}