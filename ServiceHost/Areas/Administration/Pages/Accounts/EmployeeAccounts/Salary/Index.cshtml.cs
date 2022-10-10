using System.Collections.Generic;
using System.Linq;
using AccountManagement.Application.Contracts.Employee;
using AccountManagement.Application.Contracts.Money;
using AccountManagement.Application.Contracts.Salary;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Areas.Administration.Pages.Accounts.EmployeeAccounts.Salary
{
    public class IndexModel : PageModel
    {
        public List<SalaryViewModel> Salary;
        public string Name;
        public int Id;
        private readonly ISalaryApplication _salaryApplication;
        private readonly IEmployeeApplication _employeeApplication;
        private readonly IMoneyApplication _moneyApplication;
        public IndexModel(ISalaryApplication salaryApplication, IEmployeeApplication employeeApplication, IMoneyApplication moneyApplication)
        {
            _salaryApplication = salaryApplication;
            _employeeApplication = employeeApplication;
            _moneyApplication = moneyApplication;
        }
        public void OnGet(int id)
        {
            _employeeApplication.Total_Rest();
            Salary = _salaryApplication.GetViewModel().Where(x => x.Status == true && x.Employee_Id == id).ToList();
            var employee = _employeeApplication.GetDetails(id);
            Name = employee.FullName;
            Id = id;
        }
        public IActionResult OnGetCreate(int id)
        {
            var employee = _employeeApplication.GetDetails(id);
            var commnd = new SalaryCreate()
            {
                Employee_Id = id,
                Employee = employee.FullName,
                Money_Id = employee.Money_Id,
                Money = _moneyApplication.GetDetails(employee.Money_Id).Name,
                Month_Salary = employee.Salary
            };
            return Partial("Create", commnd);
        }
        public IActionResult OnPostCreate(SalaryCreate command)
        {
            _salaryApplication.Create(command);
            return RedirectToPage("./Index", new { id = command.Employee_Id });
        }
        public IActionResult OnGetEdit(int id)
        {
            var result = _salaryApplication.GetDetails(id);
            var employee_id = _salaryApplication.GetDetails(id).Employee_Id;
            var employee = _employeeApplication.GetDetails(employee_id);
            result.Employee_Id = employee_id;
            result.Employee = employee.FullName;
            result.Money_Id = employee.Money_Id;
            result.Month_Salary = employee.Salary;
            result.Money = _moneyApplication.GetDetails(employee.Money_Id).Name;
            result.Id = id;
            return Partial("./Edit", result);
        }
        public IActionResult OnPostEdit(SalaryEdit command)
        {
            _salaryApplication.Edit(command);
            var result = _salaryApplication.GetDetails(command.Id);
            return RedirectToPage("./Index", new { id = result.Employee_Id });
        }
        public IActionResult OnGetRemoved(int id)
        {
            var commnd = new SalaryRemoved()
            {
                Salarys = _salaryApplication.GetViewModel().Where(x => x.Status == false && x.Employee_Id == id).ToList(),
                Id = Id,
            };
            return Partial("./Removed", commnd);
        }
        public IActionResult OnGetActivate(int id)
        {
            _salaryApplication.Activate(id);
            var result = _salaryApplication.GetDetails(id);
            return RedirectToPage("./Index", new { id = result.Employee_Id });
        }
        public IActionResult OnGetRemove(int id)
        {
            _salaryApplication.Remove(id);
            var result = _salaryApplication.GetDetails(id);
            return RedirectToPage("./Index", new { id = result.Employee_Id });
        }
    }
}