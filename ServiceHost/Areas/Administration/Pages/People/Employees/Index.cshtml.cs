using System.Collections.Generic;
using System.Linq;
using AccountManagement.Application.Contracts.Employee;
using AccountManagement.Application.Contracts.Money;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Areas.Administration.Pages.People.Employees
{
    public class IndexModel : PageModel
    {
        public List<EmployeeViewModel> employees;
        public List<MoneyViewModel> Moneys;

        private readonly IEmployeeApplication _employeeApplication;
        private readonly IMoneyApplication _moneyApplication;
        public IndexModel(IEmployeeApplication employeeApplication, IMoneyApplication moneyApplication)
        {
            _employeeApplication = employeeApplication;
            _moneyApplication = moneyApplication;
        }

        public void OnGet()
        {
            employees = _employeeApplication.GetEmployee().Where(x => x.Status == true && x.Access == true).ToList();
        }
        public IActionResult OnGetCreate()
        {
            var commnd = new EmployeeCreate()
            {
                Moneys = _moneyApplication.GetMoney().Where(x => x.Status == true).ToList(),
            };
            return Partial("./Create", commnd);
        }
        public IActionResult OnPostCreate(EmployeeCreate command)
        {
            _employeeApplication.Create(command);
            return RedirectToPage("./Index");
        }
        public IActionResult OnGetEdit(int id)
        {
            var account = _employeeApplication.GetDetails(id);
            account.Moneys = _moneyApplication.GetMoney();
            return Partial("Edit", account);
        }
        public IActionResult OnPostEdit(EmployeeEdit command)
        {
            _employeeApplication.Edit(command);
            return RedirectToPage("./Index");
        }
        public IActionResult OnGetRemoved()
        {
            var commnd = new Removed()
            {
                Employees = _employeeApplication.GetEmployee().Where(x => x.Status == false).ToList(),
            };
            return Partial("./Removed", commnd);
        }
        public IActionResult OnGetAccess()
        {
            var commnd = new Removed()
            {
                Employees = _employeeApplication.GetEmployee().Where(x => x.Access == false).ToList(),
            };
            return Partial("./Access", commnd);
        }
        public RedirectToPageResult OnGetActivate(int id)
        {
            _employeeApplication.Activate(id);
            return RedirectToPage("./Index");
        }
        public RedirectToPageResult OnGetRemove(int id)
        {
            _employeeApplication.Remove(id);
            return RedirectToPage("./Index");
        }
        public RedirectToPageResult OnGetOff(int id)
        {
            _employeeApplication.AccessFalse(id);
            return RedirectToPage("./Index");
        }
        public RedirectToPageResult OnGetOn(int id)
        {
            _employeeApplication.AccessTrue(id);
            return RedirectToPage("./Index");
        }
    }
}