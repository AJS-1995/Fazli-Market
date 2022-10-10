using _0_Framework.Application;
using _0_Framework.Infrastructure;
using AccountManagement.Application.Contracts.Salary;
using Domin.SalaryAgg;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Repository
{
    public class SalaryRepository : RepositoryBase<int, Salary>, ISalaryRepository
    {
        private readonly FM_Context _context;

        public SalaryRepository(FM_Context accountContext) : base(accountContext)
        {
            _context = accountContext;
        }

        public SalaryEdit GetDetails(int id)
        {
            return _context.Salarys.Select(x => new SalaryEdit
            {
                Id = x.Id,
                Money_Id = x.Money_Id,
                Month = x.Month,
                Year = x.Year,
                Employee_Id = x.Employee_Id,
                Month_Salary = x.Month_Salary
            }).FirstOrDefault(x => x.Id == id);
        }

        public List<SalaryViewModel> GetViewModel()
        {
            var money = _context.Moneys.Select(x => new { x.Id, x.Name }).ToList();
            var employee = _context.Employees.Select(x => new { x.Id, x.FullName }).ToList();
            var query = _context.Salarys.Select(x => new SalaryViewModel
            {
                Id = x.Id,
                Money_Id = x.Money_Id,
                Month = x.Month.ToMonth(),
                Year = x.Year,
                Employee_Id = x.Employee_Id,
                Month_Salary = x.Month_Salary,
                Status = x.Status
            });
            var result = query.OrderByDescending(x => x.Id).ToList();

            result.ForEach(item =>
                item.Money = money.FirstOrDefault(x => x.Id == item.Money_Id)?.Name);

            result.ForEach(item =>
                item.Employee = employee.FirstOrDefault(x => x.Id == item.Employee_Id)?.FullName);

            return result;
        }
    }
}