using AccountManagement.Application.Contracts.Electrical_System.Box_Meter.Meter;
using AccountManagement.Application.Contracts.Electrical_System.Shared_Meter;
using System.Collections.Generic;

namespace AccountManagement.Application.Contracts.Electrical_System.Box_Meter
{
    public class MeterRemoved
    {
        public int Id { get; set; }
        public List<BoxMeterViewModel> BoxMeters { get; set; }
        public List<MeterViewModel> Meters { get; set; }
        public List<MOperationViewModel> MOperations { get; set; }
        public List<MPayViewModel> MPays { get; set; }
        public List<Shared_MeterViewModel> Shared_Meters { get; set; }
        public List<MSOperationViewModel> MSOperations { get; set; }
    }
}