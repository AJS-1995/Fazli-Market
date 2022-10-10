using AccountManagement.Application.Contracts.Shop;
using System.Collections.Generic;

namespace AccountManagement.Application.Contracts.Locations
{
    public class Removed_Location
    {
        public List<ViewModel_Location> Locations { get; set; }
        public List<ViewModel_Shop> Shops { get; set; }
    }
}