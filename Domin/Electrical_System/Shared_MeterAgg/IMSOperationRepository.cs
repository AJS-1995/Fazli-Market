using _0_Framework.Domain;
using AccountManagement.Application.Contracts.Electrical_System.Shared_Meter;
using System.Collections.Generic;

namespace Domin.Electrical_System.Shared_MeterAgg
{
    public interface IMSOperationRepository : IRepository<int, MSOperation>
    {
        List<MSOperationViewModel> GetOperation();
        MSOperationEdit GetDetails(int id);
    }
}