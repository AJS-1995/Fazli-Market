using _0_Framework.Domain;
using AccountManagement.Application.Contracts.ExSlaRec;
using System.Collections.Generic;

namespace Domin.ExSlaRecAgg
{
    public interface IExSlaRecRepository : IRepository<int, ExSlaRec>
    {
        List<ExSlaRecViewModel> GetExSlaRec();
        ExSlaRecEdit GetDetails(int id);
    }
}