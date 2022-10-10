using _0_Framework.Application;
using System.Collections.Generic;

namespace AccountManagement.Application.Contracts.Expense
{
    public interface IExpenseApplication
    {
        OperationResult Create(ExpenseCreate command);
        OperationResult Edit(ExpenseEdit command);
        ExpenseEdit GetDetails(int id);
        List<ExpenseViewModel> GetExpense();
        ExpensePhoto GetPhoto(int id);
        void Remove(int id);
        void Activate(int id);
    }
}