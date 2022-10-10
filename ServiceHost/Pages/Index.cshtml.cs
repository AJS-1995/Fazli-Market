using _0_Framework.Application;
using AccountManagement.Application.Contracts.Account;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Pages
{
    public class IndexModel : PageModel
    {
        [TempData]
        public string Message { get; set; }

        private readonly IAccountApplication _accountApplication;
        private readonly IAuthHelper _authHelper;
        public IndexModel(IAccountApplication accountApplication, IAuthHelper authHelper)
        {
            _accountApplication = accountApplication;
            _authHelper = authHelper;
        }
        public IActionResult OnGet(RegisterAccount command)
        {
            var Authenticated = _authHelper.IsAuthenticated();
            if (Authenticated == true)
            {
                return Redirect("/Administration/Home");
            }
            else
            {
                var user = _accountApplication.GetAccounts();
                if (user.Count != 0)
                {
                    return Page();
                }
                else
                {
                    _accountApplication.Register(command);
                    return Page();
                }
            }
        }
        public IActionResult OnPostLogin(Login command)
        {
            OperationResult result = _accountApplication.Login(command);
            if(result.IsSuccedded == true)
            {
                return Redirect("/Administration/Home");
            }
            else
            {
                Message = result.Message;
                return Page();
            }
        }
        public IActionResult OnGetLogout()
        {
            _accountApplication.Logout();
            return RedirectToPage("/Index");
        }
    }
}