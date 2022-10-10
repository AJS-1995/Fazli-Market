using _0_Framework.Domain;
using AccountManagement.Application.Contracts.Electrical_System.Box_Meter.Meter;
using System.Collections.Generic;

namespace Domin.Electrical_System.Box_MeterAgg.MeterAgg
{
    public interface IMeterRepository : IRepository<int, Meter>
    {
        MeterEdit GetDetails(int id);
        List<MeterViewModel> GetViewModel();
    }
}