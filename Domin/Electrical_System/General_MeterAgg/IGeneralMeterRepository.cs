using _0_Framework.Domain;
using AccountManagement.Application.Contracts.Electrical_System.General_Meter;
using System.Collections.Generic;

namespace Domin.Electrical_System.General_MeterAgg
{
    public interface IGeneralMeterRepository : IRepository<int, GeneralMeter>
    {
        List<GeneralMeterViewModel> GetGeneralMeter();
        GeneralMeterEdit GetDetails(int id);
    }
}