using _0_Framework.Domain;
using AccountManagement.Application.Contracts.PayBox;
using System.Collections.Generic;

namespace Domin.PayBoxAgg
{
    public interface ITransfersPayBoxRepository : IRepository<int, TransfersPayBox>
    {
        List<ViewModel_TransfersPayBox> GetViewModel();
        Edit_TransfersPayBox GetDetails(int id);
    }
}