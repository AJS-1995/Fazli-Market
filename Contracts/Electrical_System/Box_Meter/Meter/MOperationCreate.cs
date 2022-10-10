using System.Collections.Generic;

namespace AccountManagement.Application.Contracts.Electrical_System.Box_Meter.Meter
{
    public class MOperationCreate
    {
        public int Meter_Id { get; set; }
        public string Date_Rrad { get; set; }
        public string Date_Pay { get; set; }
        public int Grade_Past { get; set; }
        public int Grade_Now { get; set; }
        public int Grade { get; set; }
        public decimal Price { get; set; }
        public int Complete { get; set; }
        public int Other { get; set; }
        public int Total { get; set; }
        public List<MeterViewModel> Meters { get; set; }
    }
}