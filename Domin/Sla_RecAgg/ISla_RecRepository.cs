using _0_Framework.Domain;
using AccountManagement.Application.Contracts.Sla_Rec;
using System.Collections.Generic;

namespace Domin.Sla_RecAgg
{
    public interface ISla_RecRepository : IRepository<int, SlaRec>
    {
        List<Sla_RecViewModel> GetSla_Rec();
        Sla_RecEdit GetDetails(int id);
    }
}