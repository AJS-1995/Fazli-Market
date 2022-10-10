using _0_Framework.Domain;
using AccountManagement.Application.Contracts.Shop_For_Rent;
using System.Collections.Generic;

namespace Domin.Shop_For_RentAgg
{
    public interface IShopForRentRepository : IRepository<int, ShopForRent>
    {
        List<ViewModel_ShopForRent> GetViewModel();
        Shop_For_RentPhoto GetPhoto(int id);
        Edit_ShopForRent GetDetails(int id);
    }
}