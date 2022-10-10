using System.Collections.Generic;
using System.Linq;
using AccountManagement.Application.Contracts.Employee;
using AccountManagement.Application.Contracts.ExSlaRec;
using AccountManagement.Application.Contracts.Money;
using AccountManagement.Application.Contracts.PayBox;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Areas.Administration.Pages.Accounts.EmployeeAccounts
{
    public class DetailsModel : PageModel
    {
        public List<ExSlaRecViewModel> exsla_rec;
        public string name;
        public int Id;
        private readonly IExSlaRecApplication _exslarecApplication;
        private readonly IEmployeeApplication _employeeApplication;
        private readonly IPayBoxApplication _payBoxApplication;
        private readonly IMoneyApplication _moneyApplication;
        public DetailsModel(IExSlaRecApplication exslarecApplication, IEmployeeApplication employeeApplication, IPayBoxApplication payBoxApplication, IMoneyApplication moneyApplication)
        {
            _exslarecApplication = exslarecApplication;
            _employeeApplication = employeeApplication;
            _payBoxApplication = payBoxApplication;
            _moneyApplication = moneyApplication;
        }
        public void OnGet(int id)
        {
            _employeeApplication.Total_Rest();
            exsla_rec = _exslarecApplication.GetViewModel().Where(x => x.Status == true && x.Employee_Id == id).ToList();
            var employee = _employeeApplication.GetDetails(id);
            name = employee.FullName;
            Id = id;
        }
        public IActionResult OnGetCreate(int id)
        {
            var employee = _employeeApplication.GetDetails(id);
            var commnd = new ExSlaRecCreate()
            {
                Employee_Id = id,
                Employee = employee.FullName,
                Money_Id = employee.Money_Id,
                PayBoxs = _payBoxApplication.GetPayBox().Where(x => x.Status == true && x.Money_Id == employee.Money_Id).ToList(),
                Money = _moneyApplication.GetDetails(employee.Money_Id).Name,
            };
            return Partial("Create", commnd);
        }
        public IActionResult OnPostCreate(ExSlaRecCreate command)
        {
            _exslarecApplication.Create(command);
            return RedirectToPage("./Details", new { id = command.Employee_Id });
        }
        public IActionResult OnGetEdit(int id)
        {
            var result = _exslarecApplication.GetDetails(id);
            var employee_id = _exslarecApplication.GetDetails(id).Employee_Id;
            var employee = _employeeApplication.GetDetails(employee_id);
            result.Employee_Id = employee_id;
            result.Employee = employee.FullName;
            result.Money_Id = employee.Money_Id;
            result.PayBoxs = _payBoxApplication.GetPayBox().Where(x => x.Status == true && x.Money_Id == employee.Money_Id).ToList();
            result.Money = _moneyApplication.GetDetails(employee.Money_Id).Name;
            result.Id = id;
            return Partial("./Edit", result);
        }
        public IActionResult OnPostEdit(ExSlaRecEdit command)
        {
            _exslarecApplication.Edit(command);
            var result = _exslarecApplication.GetDetails(command.Id);
            return RedirectToPage("./Details", new { id = result.Employee_Id });
        }
        public IActionResult OnGetRemoved(int id)
        {
            var commnd = new ExSlaRecRemoved()
            {
                ExSlaRecs = _exslarecApplication.GetViewModel().Where(x => x.Status == false && x.Employee_Id == id).ToList(),
            };
            return Partial("./Removed", commnd);
        }
        public IActionResult OnGetActivate(int id)
        {
            _exslarecApplication.Activate(id);
            var result = _exslarecApplication.GetDetails(id);
            return RedirectToPage("./Details", new { id = result.Employee_Id });
        }
        public IActionResult OnGetRemove(int id)
        {
            _exslarecApplication.Remove(id);
            var result = _exslarecApplication.GetDetails(id);
            return RedirectToPage("./Details", new { id = result.Employee_Id });
        }
    }
}