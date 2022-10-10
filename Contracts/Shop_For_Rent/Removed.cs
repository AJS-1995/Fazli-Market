using AccountManagement.Application.Contracts.ReceiptRent;
using AccountManagement.Application.Contracts.Rent;
using System.Collections.Generic;

namespace AccountManagement.Application.Contracts.Shop_For_Rent
{
    public class Removed
    {
        public List<ViewModel_ShopForRent> ShopForRents { get; set; }
        public List<RentViewModel> Rents { get; set; }
        public List<ReceiptRentViewModel> Receipts { get; set; }
        public int Id { get; set; }
        public string LocationName { get; set; }
        public string ShopName { get; set; }
    }
}