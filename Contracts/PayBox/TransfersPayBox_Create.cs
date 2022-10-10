using AccountManagement.Application.Contracts.Money;
using System.Collections.Generic;

namespace AccountManagement.Application.Contracts.PayBox
{
    public class TransfersPayBox_Create
    {
        public int PayBoxIn_Id { get; set; }
        public int PayBoxTo_Id { get; set; }
        public string By { get; set; }
        public decimal Amount { get; set; }
        public string Date { get; set; }
        public int Money_Id { get; set; }
        public string Money { get; set; }
        public List<MoneyViewModel> Moneys { get; set; }
        public List<ViewModel_PayBox> PayBoxes { get; set; }
    }
}