using System.Collections.Generic;
using System.Linq;
using AccountManagement.Application.Contracts.Expense;
using AccountManagement.Application.Contracts.ExSlaRec;
using AccountManagement.Application.Contracts.PayBox;
using AccountManagement.Application.Contracts.Sla_Rec;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Areas.Administration.Pages.Accounts.PayBox
{
    public class SlaveryModel : PageModel
    {
        public string Name;
        public List<ExpenseViewModel> Expenses;
        public List<ExSlaRecViewModel> ExSlaRecs;
        public List<Sla_RecViewModel> Sla_Recs;
        public List<ViewModel_TransfersPayBox> Transferspayboxs;

        private readonly IPayBoxApplication _payBoxApplication;
        private readonly IExSlaRecApplication _exslarecApplication;
        private readonly ISla_RecApplication _sla_RecApplication;
        private readonly IExpenseApplication _expenseApplication;
        private readonly ITransfersPayBoxApplication _transfersPayBoxApplication;
        public SlaveryModel(ITransfersPayBoxApplication transfersPayBoxApplication, IExpenseApplication expenseApplication, ISla_RecApplication sla_RecApplication, IExSlaRecApplication exslarecApplication, IPayBoxApplication payBoxApplication)
        {
            _transfersPayBoxApplication = transfersPayBoxApplication;
            _expenseApplication = expenseApplication;
            _sla_RecApplication = sla_RecApplication;
            _exslarecApplication = exslarecApplication;
            _payBoxApplication = payBoxApplication;
        }
        public void OnGet(int id)
        {
            Name = _payBoxApplication.GetDetails(id).Name;
            Expenses = _expenseApplication.GetExpense().Where(x => x.Status == true && x.PayBox_Id == id).ToList();
            ExSlaRecs = _exslarecApplication.GetViewModel().Where(x => x.Status == true && x.PayBox_Id == id && x.Type == false).ToList();
            Sla_Recs = _sla_RecApplication.GetViewModel().Where(x => x.Status == true && x.PayBox_Id == id && x.Type == false).ToList();
            Transferspayboxs = _transfersPayBoxApplication.GetTransfersPayBox().Where(x => x.Status == true && x.PayBoxIn_Id == id).ToList();
        }
    }
}