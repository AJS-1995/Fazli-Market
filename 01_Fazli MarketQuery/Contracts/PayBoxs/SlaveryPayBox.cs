using AccountManagement.Application.Contracts.Expense;
using AccountManagement.Application.Contracts.ExSlaRec;
using AccountManagement.Application.Contracts.PayBox;
using AccountManagement.Application.Contracts.Sla_Rec;
using System.Collections.Generic;

namespace _01_Fazli_MarketQuery.Contracts.PayBoxs
{
    public class SlaveryPayBox
    {
        public List<ExpenseViewModel> Expenses { get; set; }
        public List<ExSlaRecViewModel> ExSlaRecs { get; set; }
        public List<Sla_RecViewModel> Sla_Recs { get; set; }
        public List<ViewModel_TransfersPayBox> Transferspayboxs { get; set; }
    }
}