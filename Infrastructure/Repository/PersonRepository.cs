using _0_Framework.Application;
using _0_Framework.Infrastructure;
using AccountManagement.Application.Contracts.Person;
using Domin.PersonAgg;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Repository
{
    public class PersonRepository : RepositoryBase<int, Person>, IPersonRepository
    {
        private readonly FM_Context _context;

        public PersonRepository(FM_Context context) : base(context)
        {
            _context = context;
        }
        public PersonEdit GetDetails(int id)
        {
            return _context.Persons.Select(x => new PersonEdit()
            {
                Id = x.Id,
                Name = x.Name,
                Address = x.Address,
                Company = x.Company,
                Phone = x.Phone,
                Money_Id = x.Money_Id
            }).FirstOrDefault(x => x.Id == id);
        }
        public List<PersonViewModel> GetPerson()
        {
            var users = _context.Accounts.Select(x => new { x.Id, x.Username }).ToList();
            var moneys = _context.Moneys.Select(x => new { x.Id, x.Name }).ToList();
            var query = _context.Persons.Select(x => new PersonViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Address = x.Address,
                Company = x.Company,
                CreationDate = x.CreationDate.ToFarsi(),
                Phone = x.Phone,
                Status = x.Status,
                Rest = x.Rest,
                User_Id = x.User_Id,
                Money_Id = x.Money_Id
            });
            var result = query.OrderByDescending(x => x.Id).ToList();

            result.ForEach(item => item.UserName = users.FirstOrDefault(x => x.Id == item.User_Id)?.Username);

            result.ForEach(item => item.Money = moneys.FirstOrDefault(x => x.Id == item.Money_Id)?.Name);

            return result;
        }
    }
}
