using _0_Framework.Application;
using System.Collections.Generic;

namespace AccountManagement.Application.Contracts.Shop
{
    public interface IShop_Application
    {
        OperationResult Create(Create_Shop command);
        OperationResult Edit(Edit_Shop command);
        OperationResult Full(Date_Shop command);
        OperationResult Empty(Date_Shop command);
        Edit_Shop GetDetails(int id);
        List<ViewModel_Shop> GetShop();
        List<ViewModel_Locations> GetLocations(int Location_Id);
        void Remove(int id);
        void Activate(int id);
        void ShopSold(int id);
        void ShopRent(int id);
        void Rest(int id, string date);
        void Rest();
    }
}