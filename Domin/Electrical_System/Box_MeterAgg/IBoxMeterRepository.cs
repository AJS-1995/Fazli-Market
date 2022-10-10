using _0_Framework.Domain;
using AccountManagement.Application.Contracts.Electrical_System.Box_Meter;
using System.Collections.Generic;

namespace Domin.Electrical_System.Box_MeterAgg
{
    public interface IBoxMeterRepository : IRepository<int, BoxMeter>
    {
        List<BoxMeterViewModel> GetViewModel();
        BoxMeterEdit GetDetails(int id);
    }
}