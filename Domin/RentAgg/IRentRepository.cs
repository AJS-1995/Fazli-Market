using _0_Framework.Domain;
using AccountManagement.Application.Contracts.Rent;
using System.Collections.Generic;

namespace Domin.RentAgg
{
    public interface IRentRepository : IRepository<int, Rent>
    {
        RentEdit GetDetails(int id);
        RentEdit Get_Id(int Shop_Id, int Money_Id, int ForRent_Id);
        List<RentViewModel> GetViewModel();
    }
}