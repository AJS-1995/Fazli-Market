using _0_Framework.Application;
using System.Collections.Generic;

namespace AccountManagement.Application.Contracts.Shop_For_Rent
{
    public interface IShop_For_RentApplication
    {
        OperationResult Create(Create_ShopForRent command);
        OperationResult Edit(Edit_ShopForRent command);
        OperationResult Empty(Edit_ShopForRent command);
        Edit_ShopForRent GetDetails(int id);
        List<ViewModel_ShopForRent> GetViewModel();
        Shop_For_RentPhoto GetPhoto(int id);
        void Remove(int id);
        void Activate(int id);
        void Rest(int id, decimal rest);
        OperationResult Total_Rest();
    }
}