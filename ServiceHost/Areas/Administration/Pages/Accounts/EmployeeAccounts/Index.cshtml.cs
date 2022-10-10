using System.Collections.Generic;
using System.Linq;
using AccountManagement.Application.Contracts.Employee;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Areas.Administration.Pages.Accounts.EmployeeAccounts
{
    public class IndexModel : PageModel
    {
        public List<EmployeeViewModel> Employees;
        private readonly IEmployeeApplication _employeeApplication;
        public IndexModel(IEmployeeApplication employeeApplication)
        {
            _employeeApplication = employeeApplication;
        }
        public void OnGet()
        {
            _employeeApplication.Total_Rest();
            Employees = _employeeApplication.GetEmployee().Where(x => x.Status == true && x.Access == true).ToList();
        }
    }
}