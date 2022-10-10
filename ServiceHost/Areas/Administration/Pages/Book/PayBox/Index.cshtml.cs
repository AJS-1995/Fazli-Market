using System.Collections.Generic;
using System.Linq;
using _01_Fazli_MarketQuery.Contracts.PayBoxs;
using AccountManagement.Application.Contracts.Money;
using AccountManagement.Application.Contracts.PayBox;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Areas.Administration.Pages.Book.PayBox
{
    public class IndexModel : PageModel
    {
        public List<ViewModel_PayBox> payboxs;

        private readonly IPayBoxApplication _payBoxApplication;
        private readonly IMoneyApplication _moneyApplication;
        private readonly IPayBox _payBox;
        public IndexModel(IMoneyApplication moneyApplication, IPayBoxApplication payBoxApplication, IPayBox payBox)
        {
            _moneyApplication = moneyApplication;
            _payBoxApplication = payBoxApplication;
            _payBox = payBox;
        }

        public void OnGet()
        {
            _payBox.Total_PayBox();
            payboxs = _payBoxApplication.GetPayBox().Where(x => x.Status == true).ToList();
        }
        public IActionResult OnGetCreate(PayBox_Create command)
        {
            command.Moneys = _moneyApplication.GetMoney().Where(x => x.Status == true).ToList();
            return Partial("./Create", command);
        }
        public IActionResult OnPostCreate(PayBox_Create command)
        {
            _payBoxApplication.Create(command);
            return RedirectToPage("./Index");
        }
        public IActionResult OnGetEdit(int id)
        {
            var result = _payBoxApplication.GetDetails(id);
            result.Moneys = _moneyApplication.GetMoney().Where(x => x.Status == true).ToList();
            return Partial("./Edit", result);
        }
        public IActionResult OnPostEdit(Edit_PayBox command)
        {
            _payBoxApplication.Edit(command);
            return RedirectToPage("./Index");
        }
        public IActionResult OnGetRemoved()
        {
            var commnd = new MoneyRemoved()
            {
                PayBoxs = _payBoxApplication.GetPayBox().Where(x => x.Status == false).ToList(),
            };
            return Partial("./Removed", commnd);
        }
        public RedirectToPageResult OnGetRemove(int id)
        {
            _payBoxApplication.Remove(id);
            return RedirectToPage("./Index");
        }
        public RedirectToPageResult OnGetActivate(int id)
        {
            _payBoxApplication.Activate(id);
            return RedirectToPage("./Index");
        }
    }
}