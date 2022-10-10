using System.Collections.Generic;
using System.Linq;
using _01_Fazli_MarketQuery.Contracts.PayBoxs;
using AccountManagement.Application.Contracts.Money;
using AccountManagement.Application.Contracts.PayBox;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Areas.Administration.Pages.Book.TransfersPayBox
{
    public class IndexModel : PageModel
    {
        public List<ViewModel_TransfersPayBox> transferspayboxs;

        private readonly ITransfersPayBoxApplication _transfersPayBoxApplication;
        private readonly IPayBox _payBox;
        public IndexModel(IPayBox payBox, ITransfersPayBoxApplication transfersPayBoxApplication)
        {
            _payBox = payBox;
            _transfersPayBoxApplication = transfersPayBoxApplication;
        }

        public void OnGet()
        {
            _payBox.Total_PayBox();
            transferspayboxs = _transfersPayBoxApplication.GetTransfersPayBox().Where(x => x.Status == true).ToList();
        }
        public IActionResult OnGetRemoved()
        {
            var commnd = new MoneyRemoved()
            {
                TransfersPayBoxes = _transfersPayBoxApplication.GetTransfersPayBox().Where(x => x.Status == false).ToList(),
            };
            return Partial("./Removed", commnd);
        }
        public RedirectToPageResult OnGetRemove(int id)
        {
            _transfersPayBoxApplication.Remove(id);
            return RedirectToPage("./Index");
        }
        public RedirectToPageResult OnGetActivate(int id)
        {
            _transfersPayBoxApplication.Activate(id);
            return RedirectToPage("./Index");
        }
    }
}