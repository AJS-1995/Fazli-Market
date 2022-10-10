using System.Collections.Generic;

namespace AccountManagement.Application.Contracts.Electrical_System.Shared_Meter
{
    public class MSOperationCreate
    {
        public int Meter_Id { get; set; }
        public string Date_Rrad { get; set; }
        public string Date_Pay { get; set; }
        public int Grade_Past { get; set; }
        public int Grade_Now { get; set; }
        public int Grade { get; set; }
        public decimal Price { get; set; }
        public decimal Total { get; set; }
        public List<Shared_MeterViewModel> Meters { get; set; }
    }
}