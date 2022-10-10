using System.Collections.Generic;

namespace AccountManagement.Application.Contracts.Electrical_System.General_Meter
{
    public class Removed
    {
        public int Id { get; set; }
        public List<GeneralMeterViewModel> generalMeters { get; set; }
        public List<OperationViewModel> operations { get; set; }
        public List<PayViewModel>  pays { get; set; }
    }
}