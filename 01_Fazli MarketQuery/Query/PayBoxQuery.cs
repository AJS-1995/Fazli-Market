using _0_Framework.Application;
using _01_Fazli_MarketQuery.Contracts.PayBoxs;
using Domin.Electrical_System.Box_MeterAgg.MeterAgg;
using Domin.Electrical_System.General_MeterAgg;
using Domin.Expenses;
using Domin.ExSlaRecAgg;
using Domin.PayBoxAgg;
using Domin.ReceiptRentAgg;
using Domin.Sla_RecAgg;
using System.Linq;

namespace _01_Fazli_MarketQuery.Query
{
    public class PayBoxQuery : IPayBox
    {
        private readonly IPayBoxRepository _payBoxRepository;
        private readonly ITransfersPayBoxRepository _transfersPayBoxRepository;
        private readonly IExpenseRepository _expenseRepository;
        private readonly ISla_RecRepository _sla_RecRepository;
        private readonly IExSlaRecRepository _emsla_RecRepository;
        private readonly IReceiptRentRepository _receiptRentRepository;
        private readonly IMPayRepository _mPayRepository;
        private readonly IPayRepository _PayRepository;
        public PayBoxQuery(IExpenseRepository expenseRepository, ISla_RecRepository sla_RecRepository,
            IExSlaRecRepository emsla_RecRepository, IReceiptRentRepository receiptRentRepository, IPayBoxRepository payBoxRepository, ITransfersPayBoxRepository transfersPayBoxRepository, IMPayRepository mPayRepository, IPayRepository payRepository)
        {
            _expenseRepository = expenseRepository;
            _sla_RecRepository = sla_RecRepository;
            _emsla_RecRepository = emsla_RecRepository;
            _receiptRentRepository = receiptRentRepository;
            _payBoxRepository = payBoxRepository;
            _transfersPayBoxRepository = transfersPayBoxRepository;
            _mPayRepository = mPayRepository;
            _PayRepository = payRepository;
        }

        public OperationResult Total_PayBox()
        {
            var operation = new OperationResult();

            var paybox = _payBoxRepository.GetViewModel().Where(x => x.Status == true);
            foreach (var item in paybox)
            {
                decimal expense = _expenseRepository.GetExpense()
                    .Where(x => x.Status == true && x.PayBox_Id == item.Id && x.Id_Money == item.Money_Id).Sum(x => x.Amount);
                decimal slaRec_Debt = _sla_RecRepository.GetSla_Rec()
                    .Where(x => x.Status == true && x.Type == false && x.PayBox_Id == item.Id && x.Money_Id == item.Money_Id).Sum(x => x.Amount);
                decimal emsla_Rec_Debt = _emsla_RecRepository.GetExSlaRec()
                    .Where(x => x.Status == true && x.Type == false && x.PayBox_Id == item.Id && x.Money_Id == item.Money_Id).Sum(x => x.Amount);
                decimal transpaybox_Debt = _transfersPayBoxRepository.GetViewModel()
                    .Where(x => x.Status == true && x.PayBoxIn_Id == item.Id && x.Money_Id == item.Money_Id).Sum(p => p.Amount);
                decimal pay_Debt = _PayRepository.GetPay()
                    .Where(x => x.Status == true && x.PayBox_Id == item.Id).Sum(p => p.Amount);

                decimal Debt = expense + slaRec_Debt + emsla_Rec_Debt + transpaybox_Debt;


                decimal receiptRent = _receiptRentRepository.GetReceiptRent()
                    .Where(x => x.Status == true && x.PayBox_Id == item.Id && x.Money_Id == item.Money_Id).Sum(x => x.Shop_Amount);
                decimal slaRec_Cradet = _sla_RecRepository.GetSla_Rec()
                    .Where(x => x.Status == true && x.Type == true && x.PayBox_Id == item.Id && x.Money_Id == item.Money_Id).Sum(x => x.Amount);
                decimal emsla_Rec_Cradet = _emsla_RecRepository.GetExSlaRec()
                    .Where(x => x.Status == true && x.Type == true && x.PayBox_Id == item.Id && x.Money_Id == item.Money_Id).Sum(x => x.Amount);
                decimal transpaybox_Cradet = _transfersPayBoxRepository.GetViewModel()
                    .Where(x => x.Status == true && x.PayBoxTo_Id == item.Id && x.Money_Id == item.Money_Id).Sum(p => p.Amount);
                decimal mpay_Cradet = _mPayRepository.GetMPay()
                    .Where(x => x.Status == true && x.PayBox_Id == item.Id).Sum(p => p.Amount);

                decimal Cradet = receiptRent + slaRec_Cradet + emsla_Rec_Cradet + transpaybox_Cradet + mpay_Cradet;


                decimal Total = Cradet - Debt;

                var rest = _payBoxRepository.Get(item.Id);
                rest.Edit(Total);
                _payBoxRepository.SaveChanges();
            }
            return operation.Succedded();
        }
    }
}