using AccountManagement.Application.Contracts.PayBox;
using System.Collections.Generic;

namespace AccountManagement.Application.Contracts.ExSlaRec
{
    public class ExSlaRecCreate
    {
        public string Date { get; set; }
        public string Description { get; set; }
        public string By { get; set; }
        public bool Type { get; set; }
        public decimal Amount { get; set; }
        public int Money_Id { get; set; }
        public string Money { get; set; }
        public int Employee_Id { get; set; }
        public string Employee { get; set; }
        public int PayBox_Id { get; set; }
        public List<ViewModel_PayBox> PayBoxs { get; set; }
    }
}