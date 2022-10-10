using System.Collections.Generic;
using AccountManagement.Application.Contracts.Money;
using AccountManagement.Application.Contracts.Expense;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AccountManagement.Application.Contracts.PayBox;
using System.Linq;

namespace ServiceHost.Areas.Administration.Pages.Accounts.Expenses
{
    public class IndexModel : PageModel
    {
        public List<ExpenseViewModel> expenses;

        private readonly IExpenseApplication _expenseApplication;
        private readonly IMoneyApplication _moneyApplication;
        private readonly IPayBoxApplication _payBoxApplication;
        public IndexModel(IExpenseApplication expenseApplication, IMoneyApplication moneyApplication, IPayBoxApplication payBoxApplication)
        {
            _expenseApplication = expenseApplication;
            _moneyApplication = moneyApplication;
            _payBoxApplication = payBoxApplication;
        }

        public void OnGet()
        {
            expenses = _expenseApplication.GetExpense().Where(x => x.Status == true).ToList();
        }
        public IActionResult OnGetCreate()
        {
            var commnd = new ExpenseCreate()
            {
                Moneys = _moneyApplication.GetMoney().Where(x=> x.Status == true).ToList(),
                PayBoxs = _payBoxApplication.GetPayBox().Where(x => x.Status == true).ToList(),
            };
            return Partial("./Create", commnd);
        }
        public IActionResult OnPostCreate(ExpenseCreate command)
        {
            _expenseApplication.Create(command);
            return RedirectToPage("./Index");
        }
        public IActionResult OnGetEdit(int id)
        {
            var result = _expenseApplication.GetDetails(id);
            result.Moneys = _moneyApplication.GetMoney();
            result.PayBoxs = _payBoxApplication.GetPayBox();
            return Partial("./Edit", result);
        }
        public IActionResult OnPostEdit(ExpenseEdit command)
        {
            _expenseApplication.Edit(command);
            return RedirectToPage("./Index");
        }
        public IActionResult OnGetRemoved()
        {
            var commnd = new ExpenseRemoved()
            {
                Expenses = _expenseApplication.GetExpense().Where(x => x.Status == false).ToList(),
            };
            return Partial("./Removed", commnd);
        }
        public IActionResult OnGetRemove(int id)
        {
            _expenseApplication.Remove(id);
            return RedirectToPage("./Index");
        }
        public IActionResult OnGetActivate(int id)
        {
            _expenseApplication.Activate(id);
            return RedirectToPage("./Index");
        }
        public IActionResult OnGetInvoice(int id)
        {
            var result = _expenseApplication.GetPhoto(id);
            return Partial("./Invoice", result);
        }
    }
}