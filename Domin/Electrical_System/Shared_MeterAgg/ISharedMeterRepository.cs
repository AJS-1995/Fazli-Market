using _0_Framework.Domain;
using AccountManagement.Application.Contracts.Electrical_System.Shared_Meter;
using System.Collections.Generic;

namespace Domin.Electrical_System.Shared_MeterAgg
{
    public interface ISharedMeterRepository : IRepository<int, Shared_Meter>
    {
        Shared_MeterEdit GetDetails(int id);
        List<Shared_MeterViewModel> GetViewModel();
    }
}