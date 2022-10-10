using _0_Framework.Domain;
using AccountManagement.Application.Contracts.Sold;
using System.Collections.Generic;

namespace Domin.SoldAgg
{
    public interface ISoldRepository : IRepository<int, Sold>
    {
        List<ViewModel_Sold> GetViewModel();
        Edit_Sold GetDetails(int id);
    }
}