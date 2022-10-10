using AccountManagement.Application.Contracts.PayBox;
using System.Collections.Generic;

namespace AccountManagement.Application.Contracts.Money
{
    public class MoneyRemoved
    {
        public int Id { get; set; }
        public List<MoneyViewModel> Moneys { get; set; }
        public List<ViewModel_PayBox> PayBoxs { get; set; }
        public List<ViewModel_TransfersPayBox> TransfersPayBoxes { get; set; }
    }
}