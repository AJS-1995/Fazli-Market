using System.Collections.Generic;
using System.Linq;
using AccountManagement.Application.Contracts.Account;
using Contracts.Role;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Areas.Administration.Pages.Settings.Users
{
    public class IndexModel : PageModel
    {
        public List<AccountViewModel> accounts;

        private readonly IAccountApplication _accountApplication;
        private readonly IRoleApplication _roleApplication;
        public IndexModel(IAccountApplication accountApplication, IRoleApplication roleApplication)
        {
            _accountApplication = accountApplication;
            _roleApplication = roleApplication;
        }
        public void OnGet()
        {
            accounts = _accountApplication.GetAccounts().Where(x => x.Status == true).ToList();
        }
        public IActionResult OnGetCreate(RegisterAccount command)
        {
            command.Roles = _roleApplication.List();
            return Partial("./Create", command);
        }
        public IActionResult OnPostCreate(RegisterAccount command)
        {
            _accountApplication.Register(command);
            return RedirectToPage("./Index");
        }
        public IActionResult OnGetEdit(int id)
        {
            var account = _accountApplication.GetDetails(id);
            account.Roles = _roleApplication.List();
            return Partial("./Edit", account);
        }
        public IActionResult OnPostEdit(EditAccount command)
        {
            _accountApplication.Edit(command);
            return RedirectToPage("./Index");
        }
        public IActionResult OnGetChangePassword(int id)
        {
            var accountcommand = _accountApplication.GetDetails(id);
            var command = new ChangePassword { Id = id, FullName = accountcommand.Fullname };
            return Partial("./ChangePassword", command);
        }
        public IActionResult OnPostChangePassword(ChangePassword command)
        {
            _accountApplication.ChangePassword(command);
            return RedirectToPage("./Index");
        }
        public IActionResult OnGetRemoved()
        {
            var commnd = new AccountRemoved()
            {
                Accounts = _accountApplication.GetAccounts().Where(x => x.Status == false).ToList(),
            };
            return Partial("./Removed", commnd);
        }
        public RedirectToPageResult OnGetActivate(int id)
        {
            _accountApplication.Activate(id);
            return RedirectToPage("./Index");
        }
        public RedirectToPageResult OnGetRemove(int id)
        {
            _accountApplication.Remove(id);
            return RedirectToPage("./Index");
        }
    }
}