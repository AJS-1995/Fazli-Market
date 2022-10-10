using AccountManagement.Application.Contracts.Money;
using AccountManagement.Application.Contracts.PayBox;
using AccountManagement.Application.Contracts.Person;
using System.Collections.Generic;

namespace AccountManagement.Application.Contracts.Sla_Rec
{
    public class Sla_RecEdit : Sla_RecCreate
    {
        public int Id { get; set; }
        public List<MoneyViewModel> Moneys { get; set; }
        public List<PersonViewModel> Persons { get; set; }
        public List<ViewModel_PayBox> PayBox { get; set; }
    }
}