using _0_Framework.Domain;
using AccountManagement.Application.Contracts.Electrical_System.Box_Meter.Meter;
using System.Collections.Generic;

namespace Domin.Electrical_System.Box_MeterAgg.MeterAgg
{
    public interface IMOperationRepository : IRepository<int, MOperation>
    {
        List<MOperationViewModel> GetOperation();
        MOperationEdit GetDetails(int id);
    }
}