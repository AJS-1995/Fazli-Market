using _0_Framework.Application;
using _0_Framework.Infrastructure;
using AccountManagement.Application.Contracts.Expense;
using Domin.Expenses;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Repository
{
    public class ExpenseRepository : RepositoryBase<int, Expense>, IExpenseRepository
    {
        private readonly FM_Context _context;

        public ExpenseRepository(FM_Context context) : base(context)
        {
            _context = context;
        }
        public ExpenseEdit GetDetails(int id)
        {
            return _context.Expenses.Select(x => new ExpenseEdit()
            {
                Id = x.Id,
                Description = x.Description,
                Amount = x.Amount,
                N_Invoice = x.N_Invoice,
                Type = x.Type,
                Id_Money = x.Id_Money,
                Date = x.Date,
                PayBox_Id = x.PayBox_Id
            }).FirstOrDefault(x => x.Id == id);
        }

        public List<ExpenseViewModel> GetExpense()
        {
            var moneys = _context.Moneys.Select(x => new { x.Id, x.Name }).ToList();
            var users = _context.Accounts.Select(x => new { x.Id, x.Username }).ToList();
            var payboxs = _context.PayBoxs.Select(x => new { x.Id, x.Name }).ToList();
            var query = _context.Expenses.Select(x => new ExpenseViewModel
            {
                Id = x.Id,
                Description = x.Description,
                Amount = x.Amount,
                N_Invoice = x.N_Invoice,
                Type = x.Type,
                Id_Money = x.Id_Money,
                CreationDate = x.CreationDate.ToFarsi(),
                Date = x.Date,
                Ph_Invoice = x.Ph_Invoice,
                PayBox_Id = x.PayBox_Id,
                Status = x.Status,
                User_Id = x.User_Id
            });
            var Expense = query.OrderByDescending(x => x.Id).ToList();

            Expense.ForEach(item => item.Money = moneys.FirstOrDefault(x => x.Id == item.Id_Money)?.Name);

            Expense.ForEach(item => item.UserName = users.FirstOrDefault(x => x.Id == item.User_Id)?.Username);

            Expense.ForEach(item => item.PayBox = payboxs.FirstOrDefault(x => x.Id == item.PayBox_Id)?.Name);

            return Expense;
        }

        public ExpensePhoto GetPhoto(int id)
        {
            return _context.Expenses
                .Where(x => x.Id == id)
                .Select(x => new ExpensePhoto
                {
                    Id = x.Id,
                    Ph_Invoice = x.Ph_Invoice
                }).FirstOrDefault(x => x.Id == id);
        }
    }
}