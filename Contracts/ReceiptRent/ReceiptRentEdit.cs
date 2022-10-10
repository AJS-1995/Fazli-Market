using AccountManagement.Application.Contracts.Locations;
using System.Collections.Generic;

namespace AccountManagement.Application.Contracts.ReceiptRent
{
    public class ReceiptRentEdit : ReceiptRentCreate
    {
        public int Id { get; set; }
        public List<ViewModel_Location> Locations { get; set; }
    }
}