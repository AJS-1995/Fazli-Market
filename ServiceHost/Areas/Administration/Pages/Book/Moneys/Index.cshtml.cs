using System.Collections.Generic;
using System.Linq;
using AccountManagement.Application.Contracts.Money;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Areas.Administration.Pages.Moneys
{
    public class IndexModel : PageModel
    {
        public List<MoneyViewModel> moneys;

        private readonly IMoneyApplication _moneyApplication;

        public IndexModel(IMoneyApplication moneyApplication)
        {
            _moneyApplication = moneyApplication;
        }
        public void OnGet()
        {
            moneys = _moneyApplication.GetMoney().Where(x => x.Status == true).ToList();
        }
        public IActionResult OnGetCreate()
        {
            return Partial("./Create");
        }
        public IActionResult OnPostCreate(CreateMoney command)
        {
            _moneyApplication.Create(command);
            return RedirectToPage("./Index");
        }
        public IActionResult OnGetEdit(int id)
        {
            var account = _moneyApplication.GetDetails(id);
            return Partial("./Edit", account);
        }
        public IActionResult OnPostEdit(MoneyEdit command)
        {
            _moneyApplication.Edit(command);
            return RedirectToPage("./Index");
        }
        public IActionResult OnGetRemoved()
        {
            var commnd = new MoneyRemoved()
            {
                Moneys = _moneyApplication.GetMoney().Where(x => x.Status == false).ToList(),
            };
            return Partial("./Removed", commnd);
        }
        public RedirectToPageResult OnGetRemove(int id)
        {
            _moneyApplication.Remove(id);
            return RedirectToPage("./Index");
        }
        public RedirectToPageResult OnGetActivate(int id)
        {
            _moneyApplication.Activate(id);
            return RedirectToPage("./Index");
        }
    }
}