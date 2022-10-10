using AccountManagement.Application.Contracts.Account;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Areas.Administration.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IAccountApplication _accountApplication;

        public IndexModel(IAccountApplication accountApplication)
        {
            _accountApplication = accountApplication;
        }

        public RedirectToPageResult OnGet()
        {
            return RedirectToPage("/Home");
        }
        public IActionResult OnGetLogout()
        {
            _accountApplication.Logout();
            return RedirectToPage("/Index");
        }
    }
}
