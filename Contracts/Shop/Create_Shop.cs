using AccountManagement.Application.Contracts.Locations;
using System.Collections.Generic;

namespace AccountManagement.Application.Contracts.Shop
{
    public class Create_Shop
    {
        public bool Sold { get; set; }
        public int Location_Id { get; set; }
        public string Name { get; set; }
        public List<ViewModel_Location> Locations { get; set; }
    }
}