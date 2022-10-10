using _0_Framework.Domain;
using AccountManagement.Application.Contracts.Shop;
using System.Collections.Generic;

namespace Domin.ShopAgg
{
    public interface IShop_Repository : IRepository<int, Shop>
    {
        Edit_Shop GetDetails(int id);
        List<ViewModel_Shop> GetShop();
        List<ViewModel_Locations> GetLocations(int Location_Id);
    }
}