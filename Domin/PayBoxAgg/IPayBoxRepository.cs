using _0_Framework.Domain;
using AccountManagement.Application.Contracts.PayBox;
using System.Collections.Generic;

namespace Domin.PayBoxAgg
{
    public interface IPayBoxRepository : IRepository<int, PayBox>
    {
        List<ViewModel_PayBox> GetViewModel();
        Edit_PayBox GetDetails(int id);
    }
}