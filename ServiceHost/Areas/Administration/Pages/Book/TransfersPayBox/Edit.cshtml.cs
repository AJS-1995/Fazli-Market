using System.Linq;
using AccountManagement.Application.Contracts.Money;
using AccountManagement.Application.Contracts.PayBox;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ServiceHost.Areas.Administration.Pages.Book.TransfersPayBox
{
    public class EditModel : PageModel
    {
        public SelectList PayBox;

        public Edit_TransfersPayBox command;

        private readonly IPayBoxApplication _PayBoxApplication;
        private readonly ITransfersPayBoxApplication _transfersPayBoxApplication;
        private readonly IMoneyApplication _moneyApplication;
        public EditModel(IPayBoxApplication payBoxApplication, ITransfersPayBoxApplication transfersPayBoxApplication, IMoneyApplication moneyApplication)
        {
            _PayBoxApplication = payBoxApplication;
            _transfersPayBoxApplication = transfersPayBoxApplication;
            _moneyApplication = moneyApplication;
        }
        public void OnGet(int id)
        {
            command = _transfersPayBoxApplication.GetDetails(id);
            PayBox = new SelectList(_PayBoxApplication.GetPayBox().Where(x=> x.Status == true), "Id", "Name");
            command.Money = _moneyApplication.GetDetails(command.Money_Id).Name;
        }
        public RedirectToPageResult OnPost(Edit_TransfersPayBox command)
        {
            _transfersPayBoxApplication.Edit(command);
            return RedirectToPage("./Index");
        }
    }
}