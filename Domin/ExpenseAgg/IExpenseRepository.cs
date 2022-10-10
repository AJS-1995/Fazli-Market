using _0_Framework.Domain;
using AccountManagement.Application.Contracts.Expense;
using System.Collections.Generic;

namespace Domin.Expenses
{
    public interface IExpenseRepository : IRepository<int, Expense>
    {
        List<ExpenseViewModel> GetExpense();
        ExpensePhoto GetPhoto(int id);
        ExpenseEdit GetDetails(int id);
    }
}
