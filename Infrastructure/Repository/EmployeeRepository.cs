using _0_Framework.Application;
using _0_Framework.Infrastructure;
using AccountManagement.Application.Contracts.Employee;
using Domin.EmployeeAgg;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Repository
{
    public class EmployeeRepository : RepositoryBase<int, Employee>, IEmployeeRepository
    {
        private readonly FM_Context _context;

        public EmployeeRepository(FM_Context context) : base(context)
        {
            _context = context;
        }
        public EmployeeEdit GetDetails(int id)
        {
            return _context.Employees.Select(x => new EmployeeEdit()
            {
                Id = x.Id,
                FullName = x.FullName,
                Address = x.Address,
                Phone = x.Phone,
                Money_Id = x.Money_Id,
                Salary = x.Salary,
                Date = x.Date
            }).FirstOrDefault(x => x.Id == id);
        }
        public List<EmployeeViewModel> GetEmployee()
        {
            var users = _context.Accounts.Select(x => new { x.Id, x.Username }).ToList();
            var moneys = _context.Moneys.Select(x => new { x.Id, x.Name }).ToList();
            var query = _context.Employees.Select(x => new EmployeeViewModel
            {
                Id = x.Id,
                FullName = x.FullName,
                Address = x.Address,
                CreationDate = x.CreationDate.ToFarsi(),
                Phone = x.Phone,
                Status = x.Status,
                User_Id = x.User_Id,
                Money_Id = x.Money_Id,
                Salary = x.Salary,
                Rest = x.Rest,
                Access = x.Access,
                Date = x.Date
            });
            var result = query.OrderByDescending(x => x.Id).ToList();

            result.ForEach(item =>
                item.UserName = users.FirstOrDefault(x => x.Id == item.User_Id)?.Username);

            result.ForEach(item =>
                item.Money = moneys.FirstOrDefault(x => x.Id == item.Money_Id)?.Name);

            return result;

        }
    }
}