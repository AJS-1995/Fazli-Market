using AccountManagement.Application.Contracts.Money;
using System.Collections.Generic;

namespace AccountManagement.Application.Contracts.PayBox
{
    public class PayBox_Create
    {
        public string Name { get; set; }
        public decimal Rest { get; set; }
        public int Money_Id { get; set; }
        public string Money { get; set; }
        public List<MoneyViewModel> Moneys { get; set; }
    }
}