using System.Collections.Generic;
using System.Linq;
using AccountManagement.Application.Contracts.ExSlaRec;
using AccountManagement.Application.Contracts.PayBox;
using AccountManagement.Application.Contracts.ReceiptRent;
using AccountManagement.Application.Contracts.Sla_Rec;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Areas.Administration.Pages.Accounts.PayBox
{
    public class ReceiptsModel : PageModel
    {
        public string Name;
        public List<ReceiptRentViewModel> Receipts;
        public List<ExSlaRecViewModel> ExSlaRecs;
        public List<Sla_RecViewModel> Sla_Recs;
        public List<ViewModel_TransfersPayBox> Transferspayboxs;

        private readonly IPayBoxApplication _payBoxApplication;
        private readonly IReceiptRentApplication _receiptRentApplication;
        private readonly IExSlaRecApplication _exslarecApplication;
        private readonly ISla_RecApplication _sla_RecApplication;
        private readonly ITransfersPayBoxApplication _transfersPayBoxApplication;

        public ReceiptsModel(ITransfersPayBoxApplication transfersPayBoxApplication, ISla_RecApplication sla_RecApplication, IExSlaRecApplication exslarecApplication, IReceiptRentApplication receiptRentApplication, IPayBoxApplication payBoxApplication)
        {
            _transfersPayBoxApplication = transfersPayBoxApplication;
            _sla_RecApplication = sla_RecApplication;
            _exslarecApplication = exslarecApplication;
            _receiptRentApplication = receiptRentApplication;
            _payBoxApplication = payBoxApplication;
        }

        public void OnGet(int id)
        {
            Name = _payBoxApplication.GetDetails(id).Name;
            Receipts = _receiptRentApplication.GetReceiptRent().Where(x => x.Status == true && x.PayBox_Id == id).ToList();
            ExSlaRecs = _exslarecApplication.GetViewModel().Where(x => x.Status == true && x.PayBox_Id == id && x.Type == true).ToList();
            Sla_Recs = _sla_RecApplication.GetViewModel().Where(x => x.Status == true && x.PayBox_Id == id && x.Type == true).ToList();
            Transferspayboxs = _transfersPayBoxApplication.GetTransfersPayBox().Where(x => x.Status == true && x.PayBoxTo_Id == id).ToList();
        }
    }
}
