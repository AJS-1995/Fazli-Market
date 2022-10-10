using System.Linq;
using AccountManagement.Application.Contracts.Money;
using AccountManagement.Application.Contracts.PayBox;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ServiceHost.Areas.Administration.Pages.Book.TransfersPayBox
{
    public class CreateModel : PageModel
    {
        public SelectList PayBox;

        private readonly IPayBoxApplication _PayBoxApplication;
        private readonly ITransfersPayBoxApplication _transfersPayBoxApplication;
        private readonly IMoneyApplication _moneyApplication;
        public CreateModel(IPayBoxApplication payBoxApplication, ITransfersPayBoxApplication transfersPayBoxApplication, IMoneyApplication moneyApplication)
        {
            _PayBoxApplication = payBoxApplication;
            _transfersPayBoxApplication = transfersPayBoxApplication;
            _moneyApplication = moneyApplication;
        }
        public void OnGet()
        {
            PayBox = new SelectList(_PayBoxApplication.GetPayBox().Where(x=> x.Status == true), "Id", "Name");
        }
        public IActionResult OnGetPayBox(int payboxin)
        {
            var paybox = _PayBoxApplication.GetDetails(payboxin);
            var result = _PayBoxApplication.GetPayBox().Where(x => x.Status == true && x.Money_Id == paybox.Money_Id && x.Id != payboxin);
            return new JsonResult(result);
        }
        public IActionResult OnGetPayBoxTo(int payboxto)
        {
            var result = _PayBoxApplication.GetDetails(payboxto);
            result.Money = _moneyApplication.GetDetails(result.Money_Id)?.Name;
            return new JsonResult(result);
        }
        public RedirectToPageResult OnPost(TransfersPayBox_Create command)
        {
            _transfersPayBoxApplication.Create(command);
            return RedirectToPage("./Create");
        }
    }
}