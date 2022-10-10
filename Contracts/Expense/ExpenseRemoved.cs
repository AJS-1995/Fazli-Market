using System.Collections.Generic;

namespace AccountManagement.Application.Contracts.Expense
{
    public class ExpenseRemoved
    {
        public List<ExpenseViewModel> Expenses { get; set; }
    }
}